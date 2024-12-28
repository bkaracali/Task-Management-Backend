using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Soyut
{
    public interface IBaseService<T> where T : class
    {
        void Delete(int id);
    }
}
