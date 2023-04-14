using BusinessLayer.Abstracts;
using DataAccessLayer.Abstaract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blog;
        

        public BlogManager(IBlogDal blog)
        {
            _blog = blog;


        }
        public void BlogAdd(Blog blog)
        {
            _blog.Add(blog);
        }

        public void BlogDelete(Blog blog)
        {
            _blog.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _blog.Update(blog); 
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blog.GetListWithCategory();
        }

        public Blog TGetById(int id)
        {
            return _blog.GetById(id);
             
        }

        public List<Blog> GetBlogByID(int id)
        {
            //Buradaki getlistall parametre alan fonk.
            //Sartli listeleme yapacagimiz icin kullandik.
            return _blog.GetListAll(x => x.BlogiD == id);
        }

        public List<Blog> GetList()
        {
            return _blog.GetListAll(); 
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blog.GetListAll(x => x.WriterID == id);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blog.GetListAll().Take(3).ToList();
        }

        public List<Blog> GetListWithListByWriterBM(int id)
        {
            return _blog.GetListWithCategoryByWriter(id); // Bu fonksiyon EFBlogRepository icinde ek olarak yazildi
        }


    }
}
