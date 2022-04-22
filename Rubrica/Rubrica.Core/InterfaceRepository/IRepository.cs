using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Add(T item);      
        
        T GetById(int id);
    }
}
