using Microsoft.EntityFrameworkCore;
using NaijaCart.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace NaijaCartApi.Models
{
    public class Customer
    {
        [EmailAddress]
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address> Addresses { get; private set; }
        public DateTime DateJoined {  get; private set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

}
