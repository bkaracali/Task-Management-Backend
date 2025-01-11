using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repo.Soyut;
using Services.DTO;
using Services.Somut;
using Services.Soyut;

namespace API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserPasswordService _userPasswordService;
       

        public PasswordController(IPasswordService passwordService, IUserPasswordService userPasswordService)
        {
            _passwordService = passwordService;
            _userPasswordService = userPasswordService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var passwords = await _passwordService.GetAll();
            return Ok(passwords);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var password = _passwordService.GetById(id);
            if (password == null) return NotFound();
            return Ok(password);
        }
        [HttpPost]
        public IActionResult CreatePassword(PasswordDTO passwordDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Yeni bir PasswordTask oluştur
            var createdTask = _passwordService.CreatePasswordTaskWithReminder(passwordDTO);

            // Oluşturulan PasswordTask ID'siyle CreatedAtAction döndür
            return CreatedAtAction(nameof(CreatePassword), new { id = createdTask.PasswordTaskId }, createdTask);
        }

        [HttpPut]
        public IActionResult Update(PasswordTask passwordTask)
        {
            _passwordService.Update(passwordTask);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUserPassword = _userPasswordService.Find(st => st.UserPasswordId==id).FirstOrDefault();
            if (existingUserPassword == null) { 
                return NotFound();
            }
            _userPasswordService.Delete(existingUserPassword.UserPasswordId);
            _passwordService.Delete(id);

            return NoContent();
        }


    }
}
