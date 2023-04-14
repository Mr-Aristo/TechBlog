using BusinessLayer.Abstracts;
using DataAccessLayer.Abstaract;
using DataAccessLayer.Concretes;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;


namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal db)
        {
            _categorydal = db;
                
        }
        public Category GetById(int id)
        {
            return _categorydal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categorydal.GetListAll();
        }

        public void tAdd(Category t)
        {
            _categorydal.Add(t);
        }

        public void tDelete(Category t)
        {
            _categorydal.Delete(t);
        }

        public void tUpdate(Category t)
        {
            _categorydal.Delete(t);
        }
    }
}
