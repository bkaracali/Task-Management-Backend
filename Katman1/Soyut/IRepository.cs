using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repo.Soyut
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> GetAll();  // admin kullanicilarinin site "ogelerini" listeeler
        T GetById(int id);       
        void  Add(T entity);
        void  Update(T entity);
        void Delete(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);

    }
}
