using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class StockDTO
    {
        
        public string StockSymbol { get; set; }

        public string DataType { get; set; }

        public TimeSpan FetchInterval { get; set; }

        public DateTime? LastFetched { get; set; }

        public decimal? RegularMarketPrice { get; set; }

        public decimal? FiftyTwoWeekHigh { get; set; }

        public decimal? FiftyTwoWeekLow { get; set; }
    }
}
