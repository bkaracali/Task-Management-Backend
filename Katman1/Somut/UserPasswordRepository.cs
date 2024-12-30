using Enitites.Models;
using Repo.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Somut
{
    public class UserPasswordRepository : BaseRepository<UserPassword>, IUserPasswordRepository
    {
        public UserPasswordRepository(admin123Context dbcontext) : base(dbcontext)
        {
        }
    }
}
