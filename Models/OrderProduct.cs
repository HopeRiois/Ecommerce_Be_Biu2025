using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_biu.Models
{
    public class OrderProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required long OrderId { get; set; }
        public virtual required Product Product { get; set; }
        public required int Amount { get; set; }
    }
}
