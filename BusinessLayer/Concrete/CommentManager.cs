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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;
        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
            
        }
        public void CommentAdd(Comment comment)
        {
            _commentdal.Add(comment);
        }

        public void CommentDelete(Comment comment)
        {
            _commentdal.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentdal.Update(comment);    
        }

        public Comment GetById(int id)
        {
            return _commentdal.GetById(id);
        }

        public List<Comment> GetList(int id)
        {
            return _commentdal.GetListAll(x=> x.BlogID ==id );
        }
        public List<Comment> GetAllList()
        {
            return _commentdal.GetListAll();
        }
    }
}
