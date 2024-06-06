using StockValueCalculator;

namespace StockValueCalculatorTests
{
    public class InventoryTests
    {
        List<IProduct> products;
        Inventory inventory;

        public InventoryTests()
        {
            products = new List<IProduct>();
            inventory = new Inventory();
            inventory.AddProduct(new Book("Hard Ground", "Tom Waits", 184, 8.99m));
            inventory.AddProduct(new CD("Blood Money", "Tom Waits", 13, 9.99m));
            inventory.AddProduct(new Book("The World's Greatest Books", "John Bramwell", 1254, 84.99m));
            inventory.AddProduct(new CD("Sky at Night", "I am Kloot", 12, 5.99m));
        }

        [Fact]
        public void TestTotalStockValue()
        {
            //Arrange
            decimal expectedTotalStockValue = 113.16m;

            //Act

            //Assert
            Assert.Equal(expectedTotalStockValue, inventory.TotalStockValue);
        }
    }
}