using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IMessageService : IGenericService<Message>
    {

        List<Message> GetInboxListByWriter(int id);
        List<Message> GetSendboxListByWriter(int id);
        
    }
}
