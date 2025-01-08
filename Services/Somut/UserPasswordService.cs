using Entities.Models;
using Repo.Somut;
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
        public UserPasswordService(BaseRepository<UserPassword> repository) : base(repository)
        {
        }
    }
}
