namespace ecommerce_biu.Models
{
    public class Product
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ProductType { get; set; }
        public required string Value { get; set; }
        public required string Img { get; set; }
        public required Category Category { get; set; }
    }
}
