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
                throw new UnauthorizedAccessException("User does not exist.");
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

        public RegisterDTO Register(string name, string email, string password)
        {
            var ConvertToUser = new User
            {
                Email = email,
                Password = password,
                Name = name,
                Role = "User"
            };
            _repository.Add(ConvertToUser);
            return new RegisterDTO
            {
                Email = ConvertToUser.Email,
                Password = ConvertToUser.Password,
                Name = ConvertToUser.Name,
            };
        }
    }
}
