using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstaract
{
    public interface ICommentDal : IGenericRepository<Comment>
    {
        List<Comment> GetListWithBlog();//Bu fonksiyon admin tarafinda commentleri blog id ile birlikte cekebilmek icin olusturuldu.
    }
}
