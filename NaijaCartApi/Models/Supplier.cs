using NaijaCartApi.Models;

namespace NaijaCart.Api.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Id = Email;
        }

        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Address> Locations { get; set; }
        public DateTime DateJoined { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }

}
