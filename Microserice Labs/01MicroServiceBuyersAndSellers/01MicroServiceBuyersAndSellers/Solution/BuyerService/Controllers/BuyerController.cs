using BuyerService.Infrastructure;
using BuyerService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BuyerService.Controllers
{
    [Route("api/[controller]")]
    public class BuyerController : Controller
    {
        private readonly BuyerContext _buyerContext;

        public BuyerController(BuyerContext context)
        {
            _buyerContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("buyers")]
        [ProducesResponseType(typeof(IEnumerable<Buyer>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBuyers()
        {
            List<Buyer>? buyers = await _buyerContext.Buyers.ToListAsync();
            return Ok(buyers);
        }

        [HttpGet]
        [Route("buyers/{id}")]
        [ProducesResponseType(typeof(Buyer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBuyerById(int id)
        {
            Buyer buyer = await _buyerContext.Buyers.SingleOrDefaultAsync(b => b.Id == id);
            return Ok(buyer);
        }

        [HttpGet]
        [Route("buyers/{surname},{firstname}")]
        [ProducesResponseType(typeof(Buyer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBuyerByName(string surname, string firstname)
        {
            Buyer buyer = await _buyerContext.Buyers.SingleOrDefaultAsync(b => b.Surname == surname && b.FirstName == firstname);
            return Ok(buyer);
        }


        [HttpPost]
        [Route("buyers")]
        [ProducesResponseType(typeof(Buyer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> InsertBuyer(Buyer buyer)
        {
            //In reality we'd want to do some validation of the buyer object here
            _buyerContext.Buyers.Add(buyer);
            _buyerContext.SaveChanges();
            return Ok(buyer);
        }

    }
}
