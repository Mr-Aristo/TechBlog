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
    public class AboutManager : IAboutService
    {
        IAboutDal _about;
        public AboutManager(IAboutDal context)
        {
            _about = context;
                
        }
        public List<About> GetListAbout()
        {
            return _about.GetListAll();
        }
    }
}
