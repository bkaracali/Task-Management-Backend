using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Soyut;

namespace API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

     


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult? Login(string email, string password)
        {
            // Kullanıcıyı doğrula
            var userDTO = _userService.AuthUser(email, password);

            if (userDTO == null)
            {
                // Hatalı giriş durumunda 401 Unauthorized döner
                return Unauthorized(new { message = "Geçersiz e-posta veya şifre." });
            }

            // Başarılı giriş durumunda kullanıcı bilgilerini döner
            return Ok(userDTO);
        }
        [HttpPost]
        public IActionResult SignIn(string name, string email, string password)
        {
            // Kullanıcıyı doğrula
            var registerDTO = _userService.Register(name, email, password);

            // Başarılı giriş durumunda kullanıcı bilgilerini döner
            return Ok(registerDTO);
        }


    }
}
