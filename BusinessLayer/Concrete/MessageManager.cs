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
            return db.GetInboxtWithMessageByWriter(id);//=> alicinin biz oldugumuz mesaglari getirmesi icin yazilan linq
        }

        public List<Message> GetList()
        {
           return db.GetListAll();
        }

        public List<Message> GetSendboxListByWriter(int id)
        {
            return db.GetSendboxWithMessageByWriter(id);
        }

        public void tAdd(Message t)
        {
            db.Add(t);
        }


        public void tDelete(Message t)
        {
            db.Delete(t);
        }


        public void tUpdate(Message t)
        {
            db.Update(t);
        }

       
    }
}
