using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IGenericService<T>  // Refactoring yaparak kod tekrarini kaldiriyoruz. Diger serveiscleri duzenledik.
    {
        void tAdd(T t);
        void tUpdate(T t);
        void tDelete(T t);
        List<T> GetList();

        T GetById(int id);

    }
    
    
}
