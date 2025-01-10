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
        private readonly IStockDatumRepository _stockDatumRepository;
        private readonly IUserStockRepository _userStockRepository;

        private readonly IUserRepository _userRepository;
        public StockDatumService(IStockDatumRepository repository, IUserStockRepository userStockRepository, IUserRepository userRepository) : base(repository)
        {
            _stockDatumRepository = repository;
            _userStockRepository = userStockRepository;
            _userRepository = userRepository;
        }
        public async Task<StockDatum> GetDataFromYahoo(string symbol, int userid/* TimeSpan fetchinterval */ )
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
                    existingStockDatum.RegularMarketPrice = Convert.ToDecimal(data.RegularMarketPrice);
                    existingStockDatum.FiftyTwoWeekHigh = Convert.ToDecimal(data.FiftyTwoWeekHigh);
                    existingStockDatum.FiftyTwoWeekLow = Convert.ToDecimal(data.FiftyTwoWeekLow);
                    existingStockDatum.LastFetched = DateTimeOffset.FromUnixTimeSeconds(data.RegularMarketTime).DateTime;  // 1 ADET DAHA KOLON EKLENEREK BASILAN ZAMAN  ILE YAHOO NUN ALDIGI ZAMAN KARSILASTIRILABILIR
                    //existingStockDatum.FetchInterval = fetchinverval;
                    _repository.Update(existingStockDatum);
                }
                else
                {
                    // Yeni bir StockDatum kaydı ekle
                    existingStockDatum = new StockDatum
                    {
                        StockSymbol = symbol,
                        DataType = "YahooFinance",
                        RegularMarketPrice = Convert.ToDecimal(data.RegularMarketPrice),
                        FiftyTwoWeekHigh = Convert.ToDecimal(data.FiftyTwoWeekHigh),
                        FiftyTwoWeekLow = Convert.ToDecimal(data.FiftyTwoWeekLow),
                        LastFetched = DateTimeOffset.FromUnixTimeSeconds(data.RegularMarketTime).DateTime,
                        JobId = 1,

                    };

                    _repository.Add(existingStockDatum);
                }
                var testuser = new User
                {
                    Userid = userid
                };
                var checkexistuser = _userRepository.Find(sd => sd.Userid == userid).FirstOrDefault();
                if (checkexistuser == null)
                {
                    throw new Exception("Kullanıcı bulunamadı.");
                }
                var data2 = new UserStock
                {
                    UserId = userid,
                    StockId = existingStockDatum.StockId,
                };

                if (!_userStockRepository.Exists(data2))
                {
                    _userStockRepository.Add(data2);
                }




                return existingStockDatum;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata Mesajı: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        Console.WriteLine("Dahili Inner Exception: " + ex.InnerException.InnerException.Message);
                    }
                }
                throw;
            }
        }








    }
}
//private readonly IStockDatumRepository _stockDatumRepository;
//public StockDatumService(IStockDatumRepository stockDatumRepository) {
//    _stockDatumRepository = stockDatumRepository;
//}    // Convert islemini becerebilirsen buraya gerek yok CRUD islemlerini BaseRepo uzerinden halledebirsin