using BusinessLayer.Abstracts;
using DataAccessLayer.Abstaract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService

    {
        IWriterDal db;
        public WriterManager(IWriterDal writerDal)
        {
            db = writerDal;

        }

        public List<Writer> GetAllWriters()
        {
            return db.GetListAll();
        }


        public List<Writer> GetWriterById(int id)
        {
            return db.GetListAll(x => x.WriterID == id);
        }



        public void WriteAdd(Writer writer)
        {
            db.Add(writer);
        }

        public Writer WriterGetById(int id)
        {
            return db.GetById(id);
        }

        public void WriterUpdate(Writer writer)
        {
            db.Update(writer);
        }

       

    }
}
