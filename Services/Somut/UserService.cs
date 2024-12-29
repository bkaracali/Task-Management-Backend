using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enitites.Models;
using Repo.Somut;
using Repo.Soyut;
using Services.Soyut;
namespace Services.Somut
{
    internal class UserService : BaseService<User>, IUserService
    {
        public UserService(BaseRepository<User> repository) : base(repository)
        {
        }
    }
}
