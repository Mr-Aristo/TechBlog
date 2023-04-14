using DataAccessLayer.Abstaract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concretes
{
    public class UnitOfWork //: IUnitOfWork
    {
        private Context db;
      

        public UnitOfWork(Context db)
        {
            this.db = db;
        }

        //public IGenericRepository<Blog> Blogs
        //{
        //   get
        //    {
        //        if (repoBlogl == null)
        //           repoBlogl = new EFBlogRepository(db);
        //        return repoBlogl;
        //    }
        //}



        
        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
