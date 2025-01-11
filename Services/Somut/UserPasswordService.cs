using Entities.Models;
using Repo.Somut;
using Repo.Soyut;
using Services.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Somut
{
    public class UserPasswordService : BaseService<UserPassword>, IUserPasswordService
    {
        protected readonly IUserPasswordRepository _userPasswordRepository;
        public UserPasswordService(IUserPasswordRepository repository) : base(repository)
        {
            _userPasswordRepository = repository;
        }
    }
}
