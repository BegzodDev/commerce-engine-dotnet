using Commerce.Domain.Entities;

namespace Commerce.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_WithValidData_ShouldCreateProduct()
        {
            // Arrange
            var product = new Product(
                "iPhone 17",
                "Apple smartphone",
                999.99m,
                10);

            // Act
            var result = product;

            // Assert
            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.Equal("iPhone 17", result.Name);
            Assert.Equal(999.99m, result.Price);
            Assert.Equal(10, result.Stock);
            Assert.True(result.IsActive);
        }

        [Fact]
        public void CreateProduct_WithInvalidPrice_ShouldThrowException()
        {
            // Arrange
            var action = () => new Product(
                "iPhone 17",
                "Apple smartphone",
                -100,
                10);

            // Act & Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void CreateProduct_WithNegativeStock_ShouldThrowException()
        {
            // Arrange
            var action = () => new Product(
                "iPhone 17",
                "Apple smartphone",
                999.99m,
                -1);

            // Act & Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void CreateProduct_WithEmptyName_ShouldThrowException()
        {
            // Arrange
            var action = () => new Product(
                "",
                "Apple smartphone",
                999.99m,
                10);

            // Act & Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
