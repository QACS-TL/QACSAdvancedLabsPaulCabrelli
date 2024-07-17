//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.Options;
using QuickTour.Configuration;
using QuickTour.Models;

namespace QuickTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        IProductsContext _context;
        private readonly ITransient _tran;
        private readonly IScoped _scoped;
        private readonly ISingleton _single;
        private readonly FeaturesConfiguration _features;
        private readonly IConfiguration _config;
        private readonly ILogger<ProductsController> _logger;


        public ProductsController(IProductsContext context,
                                    ITransient tran,
                                    IScoped scoped,
                                    ISingleton single,
                                    IOptions<FeaturesConfiguration> features,
                                    IConfiguration config,
                                    ILogger<ProductsController> logger)
        {
            _context = context;
            _tran = tran;
            _scoped = scoped;
            _single = single;
            _features = features.Value;
            _config = config;
            _logger = logger;
        }

        [HttpGet("")]
        [HttpGet("Products")]
        [HttpGet("ProductDetails")]
        public IEnumerable<Product> ProductsDetail()
        {
            _tran.WriteGuidToConsole();
            _scoped.WriteGuidToConsole();
            _single.WriteGuidToConsole();
            _logger.LogInformation(
                $"MyOption1 = {_features.EnableMyOption1}, MyOption2 = {_features.EnableMyOption2}");

            _logger.LogInformation($"MyOption1 = {_config["Features:EnableMyOption1"]}, MyOption2 = {_config["Features:EnableMyOption2"]}");

            return _context.GetProducts();
        }

        [HttpGet("ProductDetail/{id:int}")]
        [HttpGet("Products/{id:int}")]
        [HttpGet("{id:int}")]
        public Product? ProductsDetail(int id)
        {
            Product? p = _context.GetProducts().FirstOrDefault(p => p.ProductId == id);
            return p;
        }

        [HttpGet("ProductDetail/{id:int}/{name}")]
        [HttpGet("Products/{id:int}/{name}")]
        [HttpGet("{id:int}/{name}")]
        public Product? ProductsDetail(int id, string? name)
        {
            Product? p = _context.GetProducts().FirstOrDefault(p => p.ProductId == id && p.Name == name);
            return p;
        }

        [HttpGet("ProductDetail/{name}")]
        [HttpGet("Products/{name}")]
        [HttpGet("{name}")]
        public Product? ProductsDetail(string? name)
        {
            Product? p = _context.GetProducts().FirstOrDefault(p => p.Name == name);
            return p;
        }

        [HttpGet("Ordered")]
        public IEnumerable<Product> OrderedProducts()
        {
            return _context.GetProducts().OrderBy(p => p.Name).ToList();
        }

        [HttpGet("Rare")]
        public string Rare([FromServices] IActionInjection ai)
        {
            ai.WriteGuidToConsole();
            return "That's all from rare this time!";
        }

    }
}
