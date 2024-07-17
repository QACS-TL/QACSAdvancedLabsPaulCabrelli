namespace QuickTour.Models
{
    public interface IProductsContext
    {
        public IEnumerable<Product> GetProducts();
    }
}
