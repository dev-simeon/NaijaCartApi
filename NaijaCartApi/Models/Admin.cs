using NaijaCartApi.Models;
using System.ComponentModel.DataAnnotations;

namespace NaijaCart.Api.Models
{
    public class Admin
    {
        public Admin()
        {
            Id = Email;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
