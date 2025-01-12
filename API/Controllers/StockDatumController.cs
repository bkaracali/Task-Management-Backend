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
        private readonly IUserStockService _userStockService;

        public StockDatumController(IStockDatumService stockDatumService, IUserStockService userStockService)
        {
            _stockDatumService = stockDatumService;
            _userStockService = userStockService;
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
            var existingUserStock = _userStockService.Find(st=> st.StockId == id).FirstOrDefault();
            if (existingUserStock == null) {
                return NotFound();
            }
            _userStockService.Delete(existingUserStock.UserStockId);
            _stockDatumService.Delete(id);
            return NoContent();
        }
    }
}

