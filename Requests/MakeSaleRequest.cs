namespace ecommerce_biu.Requests
{
    public class MakeSaleRequest
    {
        public required long IdOrder { get; set; }
        public required long IdUser { get; set; }
    }
}
