using System.ComponentModel.DataAnnotations.Schema;

namespace NaijaCartApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public required decimal Price { get; set; }
        public int CategoryID { get; set;}
        public required int QuantityInStock { get; set; }
        public required string Image { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }
    }
}
