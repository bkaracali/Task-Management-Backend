using Enitites.Models;
using Repo.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Somut
{
    public class UserDatumRepository : BaseRepository<StockDatum>, IStockDatumRepository
    {
        public UserDatumRepository(admin123Context dbcontext) : base(dbcontext)
        {
        }
    }
}
