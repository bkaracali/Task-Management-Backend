﻿using Entities.Models;
using Repo.Somut;
using Repo.Soyut;
using Services.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Somut
{
    public class UserStockService : BaseService<UserStock>, IUserStockService
    {
        public UserStockService(BaseRepository<UserStock> repository) : base(repository)
        {
        }
    }
}
