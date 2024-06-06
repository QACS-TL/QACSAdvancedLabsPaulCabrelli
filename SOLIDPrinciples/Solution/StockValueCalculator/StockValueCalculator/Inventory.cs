using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockValueCalculator
{
    public class Inventory
    {
        private List<IProduct> products = new List<IProduct>();

        public void AddProduct(IProduct product)
        {
            products.Add(product);
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
