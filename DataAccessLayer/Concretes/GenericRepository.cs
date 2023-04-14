using DataAccessLayer.Abstaract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected Context _context;
        //  private DbSet<T> _dbSet;

        public GenericRepository(Context dbContext)
        {
            _context = dbContext;
            // _dbSet = _context.Set<T>();
        }

        public GenericRepository() { }

        public void Add(T entity)
        {
            using var c = new Context();
            c.Add(entity);
            c.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var c = new Context();
            c.Remove(entity);
            c.SaveChanges();
        }


        List<T> IGenericRepository<T>.GetListAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();

        }

        public T GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);

        }

        public void Update(T entity)
        {
            using var c = new Context();
            c.Update(entity);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();
        }
    }
}
