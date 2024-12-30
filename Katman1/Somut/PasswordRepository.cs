using Enitites.Models;
using Repo.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Somut
{
    public class PasswordRepository : BaseRepository<PasswordTask>, IPasswordRepository
    {
        public PasswordRepository(admin123Context dbcontext) : base(dbcontext)
        {
        }
    }
}
