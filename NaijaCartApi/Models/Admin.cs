using NaijaCartApi.Models;
using System.ComponentModel.DataAnnotations;

namespace NaijaCart.Api.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
