using Entities.Models;
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
        private readonly IUserStockRepository userStockRepository;
        public StockDatumService(BaseRepository<StockDatum> repository ) : base(repository)
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

                var existingStockDatum = _repository.Find(sd => sd.StockSymbol == symbol).FirstOrDefault(); // Bu methodu baseRepoda T entity olarak verfigimiz icin Repository si set edilne her servis de bulunan entites ler icin
                // o entitinin fieldlarina erisim saglayabilirirz ornek olarak bu method userservice de userrepo olarak tanimlanirsa user.Userid ye erisim saglayabiliriz

                if (existingStockDatum != null)
                {
                    // Mevcut kaydı güncelle
                    existingStockDatum.RegularMarketPrice = data[Field.RegularMarketPrice] as decimal?;
                    existingStockDatum.FiftyTwoWeekHigh = data[Field.FiftyTwoWeekHigh] as decimal?;
                    existingStockDatum.FiftyTwoWeekLow = data[Field.FiftyTwoWeekLow] as decimal?;
                    existingStockDatum.LastFetched = data[Field.RegularMarketTime] as DateTime?;

                    _repository.Update(existingStockDatum);
                }
                else
                {
                    // Yeni bir StockDatum kaydı ekle
                    existingStockDatum = new StockDatum
                    {
                        StockSymbol = symbol,
                        DataType = "YahooFinance",
                        RegularMarketPrice = data[Field.RegularMarketPrice] as decimal?,
                        FiftyTwoWeekHigh = data[Field.FiftyTwoWeekHigh] as decimal?,
                        FiftyTwoWeekLow = data[Field.FiftyTwoWeekLow] as decimal?,
                        LastFetched = data[Field.RegularMarketTime] as DateTime?,
                        JobId = 1,
                    };

                    _repository.Add(existingStockDatum);
                }


                var data2 = new UserStock
                {
                    UserId = userid,
                    StockId = existingStockDatum.StockId,
                };
                if (!userStockRepository.Exists(data2)) {
                   userStockRepository.Add(data2);
                }
                
                                               
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