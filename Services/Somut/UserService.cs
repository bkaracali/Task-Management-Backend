using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Repo.Somut;
using Repo.Soyut;
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
    }
}
