using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstaract
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetListAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);

        //Sartli listeleme islemlerinde kullanilan bir yapidir.
        List<T> GetListAll(Expression<Func<T,bool>> filter);


    }
}
  