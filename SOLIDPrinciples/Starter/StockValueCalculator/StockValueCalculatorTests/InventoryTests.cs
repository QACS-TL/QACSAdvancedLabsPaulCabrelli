using StockValueCalculator;

namespace StockValueCalculatorTests
{
    public class InventoryTests
    {
        [Fact]
        public void TestTotalStockValue()
        {
            //Arrange
            decimal expectedTotalStockValue = 113.16m;

            //Act
            Inventory inventory = new Inventory();
            inventory.AddProduct("Hard Ground", "Tom Waits" , 184, 8.99m, "book");
            inventory.AddProduct("Blood Money", "Tom Waits", 13, 9.99m, "cd");
            inventory.AddProduct("The World's Greatest Books", "John Bramwell", 1254, 84.99m, "book");
            inventory.AddProduct("Sky at Night", "I am Kloot", 12, 5.99m, "cd");

            //Assert
            Assert.Equal(expectedTotalStockValue, inventory.TotalStockValue);



        }
    }
}