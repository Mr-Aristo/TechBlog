using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IWriterService 
    {
        void WriteAdd(Writer writer);
        void WriterUpdate(Writer writer);

        List<Writer> GetWriterById(int id);
        List<Writer> GetAllWriters();

       
        Writer WriterGetById(int id);

        
      
    }
}
