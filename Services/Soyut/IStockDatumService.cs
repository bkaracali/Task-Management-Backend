using Entities.Models;
using Services.DTO;
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
        public Task<StockDTO> GetDataFromYahoo(string StockSymbol, int userid/* TimeSpan fetchinterval */);


    }
}
