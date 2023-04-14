using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IBlogService
    {
        void BlogAdd(Blog blog);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);

        List<Blog> GetList();
        Blog TGetById(int id);

        List<Blog> GetBlogListWithCategory();

        List<Blog> GetBlogListByWriter(int id );

        public List<Blog> GetBlogByID(int id);
        public List<Blog> GetListWithListByWriterBM(int id);
        public List<Blog> GetLast3Blog();



    }
}
  