using DataAccessLayer.Abstaract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concretes;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameworkRepos
{
    public class EFMessageRepository : GenericRepository<Message>, IMessageDal
    {

        public List<Message> GetInboxtWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {

                return c.Messages.Include(x => x.SenderUser).Where(x => x.RecieverID == id).ToList();

            }
        }

        public List<Message> GetSendboxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages.Include(x => x.RecieverUser).Where(y => y.SenderID == id).ToList();
            }
        }
    }
}
