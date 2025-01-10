using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Soyut
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(); // Admin kullanıcıların site "öğelerini" listelemesi
        T GetById(int id);                  // ID'ye göre veri alımı
        void Add(T entity);                 // Veri ekleme
        void Update(T entity);              // Veri güncelleme
        void Delete(int id);                // ID'ye göre silme
        IEnumerable<T> Find(Func<T, bool> predicate); // Koşula göre veri arama
    }
}
