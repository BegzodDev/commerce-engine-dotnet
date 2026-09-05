using System.Runtime.CompilerServices;

namespace Commerce.Domain.Entities
{
    public class Product
    {
        public Product(string name, string description, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty");
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            if (stock < 0)
                throw new ArgumentException("Stock cannot be negative.");
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (quantity > Stock)
                throw new InvalidOperationException("Insufficient stock.");

            Stock -= quantity;
        }
        /// <summary>
        /// IDENIFY FOR PRODUCT
        /// </summary>
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; set; }
    }
}
