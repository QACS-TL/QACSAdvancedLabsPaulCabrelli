using System.Diagnostics;

namespace StockValueCalculator
{
    public class CD: IProduct
    {
        public string Name { get; set; }
        public string Artist { get; private set; }
        public int Tracks { get; private set; }
        public decimal BasePrice { get; set; }
        public decimal VATRate { get; } = 1.20m;
        public decimal PriceIncludingVAT
        {
            get
            {
                return decimal.Round(BasePrice * VATRate, 2);  // 20% VAT on CDs
            }
        }

        public CD(string name, string artist, int tracks, decimal basePrice)
        {
            Name = name;
            Artist = artist;
            Tracks = tracks;
            BasePrice = basePrice;
        }
    }
}
