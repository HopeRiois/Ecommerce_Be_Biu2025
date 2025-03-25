using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_biu.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required DateTime OrderDate { get; set; }
        public required string Status { get; set; }
        public virtual required User User { get; set; }
        public virtual required List<OrderProduct> OrderProducts { get; set; }

    }
}
