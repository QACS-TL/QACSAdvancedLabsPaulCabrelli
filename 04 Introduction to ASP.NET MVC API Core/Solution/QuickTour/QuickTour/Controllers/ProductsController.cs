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
        [HttpGet("")]
        [HttpGet("Products")]
        [HttpGet("ProductDetails")]
        public IEnumerable<Product> ProductsDetail()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { ProductId = 1, Name = "Rolos" });
            products.Add(new Product { ProductId = 2, Name = "Bag of Crisps" });
            products.Add(new Product { ProductId = 3, Name = "Apple" });
            products.Add(new Product { ProductId = 4, Name = "Cheese Sandwich" });
            return products;
        }

        [HttpGet("ProductDetail/{id:int}")]
        [HttpGet("Products/{id:int}")]
        [HttpGet("{id:int}")]
        public Product ProductsDetail(int id)
        {
            Product p = new Product { ProductId = id, Name = "Rolos" };
            return p;
        }

        [HttpGet("ProductDetail/{name}")]
        [HttpGet("Products/{name}")]
        [HttpGet("{name}")]
        public Product ProductsDetail(string name)
        {
            Product p = new Product { ProductId = 4, Name = name };
            return p;
        }

        [HttpGet("Ordered")]
        public IEnumerable<Product> OrderedProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { ProductId = 1, Name = "Rolos" });
            products.Add(new Product { ProductId = 2, Name = "Bag of Crisps" });
            products.Add(new Product { ProductId = 3, Name = "Apple" });
            products.Add(new Product { ProductId = 4, Name = "Cheese Sandwich" });
            return products.OrderBy(p => p.Name).ToList();
        }
    }
}
