using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enitites.Models;

namespace Repo.Soyut
{
    public interface IRepository<T> 
    {
        Task <IEnumerable<T>> GetAll();
        T GetById(int id);       
        void  Add(T entity);
        void  Update(T entity);
        void Delete(int id);

    }
}
