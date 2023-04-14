using BusinessLayer.Abstracts;
using DataAccessLayer.Abstaract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal db;

        public NotificationManager(INotificationDal db)
        {
            this.db = db;
        }

        public Notification GetById(int id)
        {
            return db.GetById(id);
        }

        public List<Notification> GetList()
        {
            return db.GetListAll();

        }

        public void tAdd(Notification t)
        {
          db.Add(t);
        }

        public void tDelete(Notification t)
        {
            db.Delete(t);
        }

        public void tUpdate(Notification t)
        {
            db.Update(t);
        }
    }
}
