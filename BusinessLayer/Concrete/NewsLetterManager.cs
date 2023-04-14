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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetter;

        public NewsLetterManager(INewsLetterDal context)
        {
            _newsLetter=context;
        }

        public void AddNewsLetter(NewsLetter nw)
        {
            _newsLetter.Add(nw);
        }
    }
}
