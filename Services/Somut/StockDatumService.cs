﻿using Enitites.Models;
using Repo.Somut;
using Repo.Soyut;
using Services.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;
namespace Services.Somut
{
    public class StockDatumService : BaseService<StockDatum>, IStockDatumService
    {
      private readonly IUserStockRepository userStockRepository ;
        public StockDatumService(BaseRepository<StockDatum> repository) : base(repository)
        {
          
            
        }
        public async Task<Security> GetDataFromYahoo( string symbol, int userid) 
        {
            // yahoo ya gidiyo input olarak cekiyo 
            // gelen veriyi stockdatuma cevirip db ye kaydediyor/



            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Hisse senedi sembolü belirtilmelidir.");
            }

            try
            {
                // Yahoo Finance API'den veri çek
                var securities = await Yahoo.Symbols(symbol).Fields(
                    Field.Symbol,
                    Field.RegularMarketPrice,
                    Field.RegularMarketTime,
                    Field.FiftyTwoWeekHigh,
                    Field.FiftyTwoWeekLow
                ).QueryAsync();

                // Gelen veriyi kontrol et
                if (!securities.ContainsKey(symbol))
                {
                    throw new Exception($"Sembol için veri bulunamadı: {symbol}");
                }

                var data = securities[symbol];

                // `StockDatum` formatına dönüştür
                var stockDatum = new StockDatum
                {                    
                    StockSymbol = symbol,
                    DataType = "YahooFinance", // Veri tipini belirtelim                
                    LastFetched = data[Field.RegularMarketTime] as DateTime?, // Son işlem zamanı
                    JobId = 1,
                    // Diğer alanlar:
                    // UserStocks ve Job ilişkisi EF tarafından lazy loading ile yönetilecek
                };
                _repository.Add(stockDatum);
                
                var data2 = new UserStock
                {
                    UserId = userid,
                    StockId = stockDatum.StockId,
                };
              userStockRepository.Add(data2);         
                                               
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hisse verileri alınırken hata oluştu: {ex.Message}");
                throw;
            }
        }








    }
}
//private readonly IStockDatumRepository _stockDatumRepository;
//public StockDatumService(IStockDatumRepository stockDatumRepository) {
//    _stockDatumRepository = stockDatumRepository;
//}    // Convert islemini becerebilirsen buraya gerek yok CRUD islemlerini BaseRepo uzerinden halledebirsin