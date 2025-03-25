using ecommerce_biu.Models;

namespace ecommerce_biu.Responses
{
    public class BuyProductsResponse
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
