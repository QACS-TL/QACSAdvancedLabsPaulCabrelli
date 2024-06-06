using System.Diagnostics;

namespace StockValueCalculator
{
    public class Product
    {
        public string Name { get; set; }
        public string AuthorArtist { get; set; }
        public int PagesTracks { get; set; }
        public decimal BasePrice { get; set; }
        public decimal PriceIncludingVAT 
        { 
            get
            {
                if (Type == "book")
                {
                    return BasePrice;  // Books are exempt from VAT
                }
                else if (Type == "cd")
                {
                    return decimal.Round(BasePrice * 1.20m, 2);  // 20% VAT on CDs
                }
                else
                {
                    throw new NotSupportedException("Unsupported product type.");
                }
            }
        }
        public string Type { get; set; }

        public Product(string name, string authorArtist, int pagesTracks, decimal basePrice, string type)
        {
            Name = name;
            AuthorArtist = authorArtist;
            PagesTracks = pagesTracks;
            BasePrice = basePrice;
            Type = type;
        }
   
    }
}
