using System.Diagnostics;

namespace StockValueCalculator
{
    public class Book: IProduct
    {
        public string Name { get; set; }
        public string Author { get; private set; }
        public int Pages { get; private set; }
        public decimal BasePrice { get; set; }
        public decimal PriceIncludingVAT 
        { 
            get
            {
                return BasePrice;  // Books are exempt from VAT
            }
        }

        public Book(string name, string author, int pages, decimal basePrice)
        {
            Name = name;
            Author = author;
            Pages = pages;
            BasePrice = basePrice;
        }
   
    }
}
