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
    public class BaseService<T> : IBaseService<T> where T : class   // oracleRepo MyRepo  Irepo
    {
        protected  readonly IRepository<T> _repository;     

        public BaseService(IRepository<T> repository) { 
            _repository = repository;   // Dependency Injection
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _repository.Find(predicate);
        }


    }
}


