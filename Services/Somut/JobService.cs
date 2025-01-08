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
    public class JobService : BaseService<Job>, IJobService
    {
        public JobService(BaseRepository<Job> repository) : base(repository)
        {
        }
    }
}
