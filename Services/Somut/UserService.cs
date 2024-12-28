using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enitites.Models;
using Repo.Soyut;
using Services.Soyut;
namespace Services.Somut
{
    internal class UserService : BaseService<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}
