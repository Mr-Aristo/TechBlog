using DataAccessLayer.Abstaract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concretes;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;//include metodu icin gerekli olan library
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public EFBlogRepository(Context dbContext) : base(dbContext)
        {
        }

        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
            {
                //include fonk kullanilirken hangi entitiy 
                //include edilecek belirtilmeli.Birnevi entitiy dahil ediliyor. 
                return c.Blogs.Include(x=> x.Category).ToList();
                  
            }


        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                 
                return c.Blogs.Include(x => x.Category).Where(x=> x.WriterID==id).ToList();

            }
        }
    }
}
