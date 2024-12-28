using Enitites.Models;
using Repo.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Somut
{
    public class UserStockRepository : BaseRepository<UserStock>, IUserStockRepository
    {
        public UserStockRepository(admin123Context dbcontext) : base(dbcontext)
        {
        }
    }
}
