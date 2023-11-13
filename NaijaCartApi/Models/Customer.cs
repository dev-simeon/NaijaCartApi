using NaijaCart.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace NaijaCartApi.Models
{
    public class Customer
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Address Address { get; private set; }
        public DateTime DateJoined {  get; private set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

}
