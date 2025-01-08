using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repo.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Somut
{
    public class StockDatumRepository : BaseRepository<StockDatum>, IStockDatumRepository
    {
        public StockDatumRepository(admin123Context dbcontext) : base(dbcontext)
        {
        }

      
    }
}
