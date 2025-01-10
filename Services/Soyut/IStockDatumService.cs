using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;


namespace Services.Soyut
{
    public interface IStockDatumService : IBaseService<StockDatum>
    {
        public Task<StockDatum> GetDataFromYahoo(string symbol, int userid/* TimeSpan fetchinterval */);


    }
}
