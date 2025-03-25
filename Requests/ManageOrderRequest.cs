namespace ecommerce_biu.Requests
{
    public class ManageOrderRequest
    {
        public required long IdUser { get; set; }
        public required long IdProduct { get; set; }
        public required int Amount { get; set; }
        public required bool IsAdding { get; set; }
    }
}
