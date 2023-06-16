using BusinessLayer.Abstracts;
using DataAccessLayer.Abstaract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public AppUser GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<AppUser> GetList()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUser>> GetUserAsync()
        {
            using (Context c = new Context())
            {
              return await c.Users.ToListAsync();
            }
        }

        public void tAdd(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void tDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void tUpdate(AppUser t)
        {
            _userDal.Update(t);
        }


    }
}
