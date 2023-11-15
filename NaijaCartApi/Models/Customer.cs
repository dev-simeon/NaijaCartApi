using Microsoft.EntityFrameworkCore;
using NaijaCart.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace NaijaCartApi.Models
{
    public class Customer
    {
        public Customer()
        {
            Id = Email;
        }

        public string Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address> Addresses { get; set; }
        public DateTime DateJoined {  get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}
