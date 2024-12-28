using Enitites.Models;
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
    public class BaseService<T> : IBaseService<T> where T : class   // oracleRepo MyRepo  Irepo
    {
        private readonly BaseRepository<T> _repository;     

        public BaseService(BaseRepository<T> repository) { 
            _repository = repository;   // Dependency Injection
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}


