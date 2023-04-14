using BusinessLayer.Abstracts;
using DataAccessLayer.Abstaract;
using EntityLayer.Concrete;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal db;

        public MessageManager(IMessageDal db)
        {
            this.db = db;
        }

        public Message GetById(int id)
        {
          return db.GetById(id);
        }

        public List<Message> GetInboxListByWriter(int id)
        {
            return db.GetListWithMessageByWriter(id);//=> alicinin biz oldugumuz mesaglari getirmesi icin yazilan linq
        }

        public List<Message> GetList()
        {
           return db.GetListAll();
        }

                 
        public void tAdd(Message t)
        {
            throw new NotImplementedException();
        }


        public void tDelete(Message t)
        {
            throw new NotImplementedException();
        }


        public void tUpdate(Message t)
        {
            throw new NotImplementedException();
        }


        Message IGenericService<Message>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
