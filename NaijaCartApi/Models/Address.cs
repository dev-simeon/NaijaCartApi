using NaijaCartApi.Models;

namespace NaijaCart.Api.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string Street { get; set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; set; }
        public string Country { get; private set; }

        public virtual Customer Customer { get; set; }
    }
}
