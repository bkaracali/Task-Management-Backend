using Entities.Models;
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
        private readonly IUserStockRepository _userStockRepository;
        public UserStockService(IUserStockRepository repository) : base(repository)
        {
            _userStockRepository= repository;
        }
    }
}
