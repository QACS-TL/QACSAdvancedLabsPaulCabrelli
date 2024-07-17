namespace QuickTour.Models
{
    public class MockProductsContext: IProductsContext
    {
        private readonly ITransient _tran;
        private readonly IScoped _scoped;
        private readonly ISingleton _single;

        public MockProductsContext(ITransient tran,
                        IScoped scoped,
                        ISingleton single)
        {
            _tran = tran;
            _scoped = scoped;
            _single = single;
        }

        public IEnumerable<Product> GetProducts()
        {
            _tran.WriteGuidToConsole();
            _scoped.WriteGuidToConsole();
            _single.WriteGuidToConsole();

            return new List<Product>() {
                new Product { ProductId = 1, Name = "Rolos" },
                new Product { ProductId = 2, Name = "Bag of Crisps" },
                new Product { ProductId = 3, Name = "Apple" },
                new Product { ProductId = 4, Name = "Cheese Sandwich" },
                new Product { ProductId = 5, Name = "Can of Coke" }
            };
        }

    }
}
