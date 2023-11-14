using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NaijaCartApi.Models
{
    public class Product
    {
        public Product()
        {
            Id = Name;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //[Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string CategoryId { get; set;}
        public int QuantityInStock { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Category Category { get; set; }
    }
}
