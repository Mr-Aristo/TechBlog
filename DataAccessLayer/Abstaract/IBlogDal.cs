using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstaract
{
    public interface IBlogDal: IGenericRepository<Blog>
    {
        List<Blog> GetListWithCategory(); // Bu fonksiyon bloglari kategory id ile cekebilmek icin tanimlandi. Bu sayede category entityede erisebilecez.
        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
