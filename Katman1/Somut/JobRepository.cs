using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enitites.Models;

using Repo.Soyut;

namespace Repo.Somut
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(admin123Context dbcontext) : base(dbcontext)
        {
        }
    }
}
