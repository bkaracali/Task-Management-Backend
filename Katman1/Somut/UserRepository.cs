
using Enitites.Models;
using Microsoft.EntityFrameworkCore;
using Repo.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Somut
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(admin123Context dbContext) : base(dbContext)
        {
        }      

       
    }
}
