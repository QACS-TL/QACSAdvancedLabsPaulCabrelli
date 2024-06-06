using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockValueCalculator
{
    public interface IProduct
    {
        string Name { get; }
        decimal BasePrice { get; }
        decimal PriceIncludingVAT { get; }

    }
}
