using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace NaijaCartApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set;}
        public int QuantityInStock { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }
    }
}
