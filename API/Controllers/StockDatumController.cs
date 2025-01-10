using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Soyut;

namespace API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StockDatumController : ControllerBase
    {
        private readonly IStockDatumService _stockDatumService;

        public StockDatumController(IStockDatumService stockDatumService)
        {
            _stockDatumService = stockDatumService;
        }

        // GET: api/StockDatum
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _stockDatumService.GetAll();
            return Ok(users);
        }
    
        

        // GET: api/StockDatum/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _stockDatumService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPut]
        public IActionResult Update(StockDatum stockDatum)
        {
            _stockDatumService.Update(stockDatum);
            return NoContent();
        }





        // PUT: api/StockDatum/{id}
        [HttpPost("Yahoo/{symbol}")]
        public async Task<IActionResult> CreateStockData(string symbol,int userid /* TimeSpan fetchinterval */ )
        {
            try
            {
                // Yahoo'dan hisse verisini al
                var data = await _stockDatumService.GetDataFromYahoo(symbol, userid);
                return Ok(data); // Veriyi döndür
            }
            catch (Exception ex)
            {
                // Hata durumunda anlamlı bir mesaj döndür
                return BadRequest($"Hata oluştu: {ex.Message}");
            }
        }

        // DELETE: api/StockDatum/{id}
       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _stockDatumService.Delete(id);
            return NoContent();
        }
    }
}

