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
    public class ContactManager :IContactService
    {
        IContactDal con;

        public ContactManager(IContactDal cn)
        {
            this.con = cn;   
        }

        public void Add(Contact cn)
        {
            con.Add(cn);
        }
    }
}
