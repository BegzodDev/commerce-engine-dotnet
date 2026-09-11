namespace Commerce.Application.Products.UpdateProduct
{
    public class UpdateProduct
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock  { get; set; }
    }
}
