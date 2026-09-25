namespace Commerce.Application.Products.UpdateStock
{
    public class UpdateStockCommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public bool Increase { get; set; }

    }
}
