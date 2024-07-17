//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using QuickTour.Models;

namespace QuickTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        List<Product> _products = new List<Product>();
        public ProductsController()
        {
            _products.Add(new Product { ProductId = 1, Name = "Rolos" });
            _products.Add(new Product { ProductId = 2, Name = "Bag of Crisps" });
            _products.Add(new Product { ProductId = 3, Name = "Apple" });
            _products.Add(new Product { ProductId = 4, Name = "Cheese Sandwich" });
        }

        [HttpGet("")]
        [HttpGet("Products")]
        [HttpGet("ProductDetails")]
        public IEnumerable<Product> ProductsDetail()
        {
            return _products;
        }

        [HttpGet("ProductDetail/{id:int}")]
        [HttpGet("Products/{id:int}")]
        [HttpGet("{id:int}")]
        public Product? ProductsDetail(int id)
        {
            Product? p = _products.FirstOrDefault(p => p.ProductId == id);
            return p;
        }

        [HttpGet("ProductDetail/{id:int}/{name}")]
        [HttpGet("Products/{id:int}/{name}")]
        [HttpGet("{id:int}/{name}")]
        public Product? ProductsDetail(int id, string? name)
        {
            Product? p = _products.FirstOrDefault(p => p.ProductId == id && p.Name == name);
            return p;
        }

        [HttpGet("ProductDetail/{name}")]
        [HttpGet("Products/{name}")]
        [HttpGet("{name}")]
        public Product? ProductsDetail(string? name)
        {
            Product? p = _products.FirstOrDefault(p => p.Name == name);
            return p;
        }

        [HttpGet("Ordered")]
        public IEnumerable<Product> OrderedProducts()
        {
            return _products.OrderBy(p => p.Name).ToList();
        }
    }
}
