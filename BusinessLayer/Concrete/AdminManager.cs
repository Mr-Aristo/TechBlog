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
    public class AdminManager : IAdminService
    {
        IAdminDal _admin;

        public AdminManager(IAdminDal admin)
        {
            _admin = admin;
        }

        public Admin GetById(int id)
        {
            return _admin.GetById(id);
        }

        public List<Admin> GetList()
        {
            return _admin.GetListAll();
        }

        public void tAdd(Admin t)
        {
            _admin.Add(t);  
        }

        public void tDelete(Admin t)
        {
            _admin.Delete(t);
        }

        public void tUpdate(Admin t)
        {
            _admin.Update(t);
        }
    }
}
