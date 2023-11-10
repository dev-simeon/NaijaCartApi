using System.ComponentModel.DataAnnotations;

namespace NaijaCartApi.Models
{
    public class Customer
    {
        public int Id { get; private set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public DateTime DateJoined {  get; private set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

}
