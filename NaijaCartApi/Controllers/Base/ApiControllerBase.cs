using Microsoft.AspNetCore.Mvc;
using NaijaCartApi.Attributes;
using NaijaCartApi.Contracts.QueryHelpers;
using NaijaCartApi.EntityFramework;
using NaijaCartApi.Models;
using NaijaCartApi.Shared;
using System.Net;
using System.Security.Claims;

namespace AirportTaxi.Api.Controllers
{
#if !DEBUG
    [Microsoft.AspNetCore.Authorization.Authorize]
#endif
    [ApiController]
    [ApiExceptionFilter]
    [Produces("application/json")]
    public abstract class ApiControllerBase : ControllerBase
    {
        public ApiControllerBase(NaijaCartContext uow)
        {
            UoW = uow;
        }

        protected T Created<T>(Uri location, T response)
        {
            Response.StatusCode = (int)HttpStatusCode.Created;
            Response.Headers.Location = location.AbsolutePath;
            return response;
        }

        protected async Task<IEnumerable<TDestination>> PagedListAsync<TSource, TDestination>(
            IQueryable<TSource> query, PaginationQuery paging,
            Func<TSource, TDestination> converter)
        {
            var list = await query.ToPagedListAsync(paging);

            Response.Headers.Add(Settings.Headers.PAGE_SIZE, list.PageSize.ToString());
            Response.Headers.Add(Settings.Headers.PAGE_NUMBER, list.PageNumber.ToString());
            Response.Headers.Add(Settings.Headers.TOTAL_PAGES, list.TotalPages.ToString());
            Response.Headers.Add(Settings.Headers.TOTAL_ITEMS, list.TotalItems.ToString());

            return list.Select(converter);
        }

        protected async Task<ActionResult<IEnumerable<TDestination>>> PagedResultAsync<TSource, TDestination>(
            IQueryable<TSource> query, PaginationQuery paging,
            Func<TSource, TDestination> converter)
        {
            var list = await PagedListAsync(query, paging, converter);
            return new OkObjectResult(list);
        }

        protected ActionResult PagedResult<TSource, TDestination>(
            IList<TSource> query, PaginationQuery paging,
            Func<TSource, TDestination> converter)
        {
            var list = query.ToPagedList(paging);

            Response.Headers.Add(Settings.Headers.PAGE_SIZE, list.PageSize.ToString());
            Response.Headers.Add(Settings.Headers.PAGE_NUMBER, list.PageNumber.ToString());
            Response.Headers.Add(Settings.Headers.TOTAL_PAGES, list.TotalPages.ToString());
            Response.Headers.Add(Settings.Headers.TOTAL_ITEMS, list.TotalItems.ToString());

            return new OkObjectResult(list.Select(converter));
        }
        protected NaijaCartContext UoW { get; }

        protected async Task<Customer> GetCurrentOwnerAsync() //USE CACHE!
        {
            var account = await UoW.Customers.FindAsync(CurrentMemberID);

            if (account == null)
                throw new Exception("Invalid LoginUser - AccountID is NULL");

            return account;
        }

        protected string CurrentMemberID
        {
            get
            {
                if (HttpContext.User == null)
                    throw new Exception("Invalid LoginUser Principal");

                return HttpContext.User.Claims
                    .Single(x => x.Type == ClaimTypes.Sid).Value;
            }
        }
    }
}

