using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockValueCalculator
{
    public class Inventory
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(string name, string authorArtist, int pagesTracks, decimal basePrice, string type)
        {
            products.Add(new Product(name, authorArtist, pagesTracks, basePrice, type));
        }

        public decimal TotalStockValue
        {
            get
            {
                decimal total = 0m;
                foreach (var product in products)
                {
                    total += product.PriceIncludingVAT;
                }
                return total;
            }
        }
    }
}
