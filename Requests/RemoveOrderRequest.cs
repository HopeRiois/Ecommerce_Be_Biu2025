namespace ecommerce_biu.Requests
{
    public class RemoveOrderRequest
    {
        public required long IdOrder { get; set; }
        public required long IdOrderProduct { get; set; }
    }
}
