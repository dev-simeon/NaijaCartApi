using System.ComponentModel.DataAnnotations.Schema;

namespace NaijaCartApi.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}