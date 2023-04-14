using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstaract
{
    public interface IUnitOfWork
    {
        IGenericRepository<Blog> Blogs { get; }


        int Save();

    }
}
