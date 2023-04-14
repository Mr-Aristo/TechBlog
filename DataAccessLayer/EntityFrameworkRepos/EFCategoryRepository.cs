using DataAccessLayer.Abstaract;
using DataAccessLayer.Concretes;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public  class EFCategoryRepository : GenericRepository<Category>,ICategoryDal
    {
    }
}
