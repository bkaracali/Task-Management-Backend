using Repo.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repo.Somut
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
       protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _tables; // operasyonun yapilacagi tableyi tespit eden

        public BaseRepository(admin123Context dbcontext)
        {
            _dbContext = dbcontext;
            _tables = _dbContext.Set<T>();
        }

        public  void Add(T entity)
        {
            _tables.Add(entity);
            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {

            var entity = _tables.FirstOrDefault(t => t.Equals(id));
            if (entity != null)
            {
                _tables.Remove(entity);
            }
            else
            {
                throw new Exception("There is no such a entity that has that id");
            }
            _dbContext.SaveChanges();

        }

        public Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> entities = _tables.ToList();   // IEnumerable ve IQueryable t]rler]ne bak !!
            return Task.FromResult(entities);

        }

        public T GetById(int id)
        {
            var entity = _tables.FirstOrDefault(t => t.Equals(id));
            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new Exception($"Unable to find id {id}");  // exception > return type
            }
        }

        public void Update(T entity)
        {
            _tables.Update(entity);
            _dbContext.SaveChanges();

        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _tables.AsQueryable().Where(predicate).ToList();
        }
    }
}



// services.AddScoped(typeof(IRepository<>),typeof(Repository<>));