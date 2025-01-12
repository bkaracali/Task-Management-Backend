using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Repo.Somut;
using Repo.Soyut;
using Services.DTO;
using Services.Soyut;
namespace Services.Somut
{
    internal class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _userRepository = repository;

        }
        public LoginDTO AuthUser(string email, string password)
        {
            var checkUser = _repository.Find(u => u.Email == email && u.Password == password).FirstOrDefault();


            if (checkUser == null)
            {
                return null;
            }
            else
            {
                return new LoginDTO
                {
                    Userid = checkUser.Userid,
                    Email = checkUser.Email,
                    Password = checkUser.Password

                };
            }

        }

        public RegisterDTO Register(RegisterDTO registerDTO)
        {
            var ConvertToUser = new User
            {
                Email = registerDTO.Email,
                Password = registerDTO.Password,
                Name = registerDTO.Name,
                Role = "User"
            };
            _repository.Add(ConvertToUser);
            return registerDTO;
        }
    }
}
