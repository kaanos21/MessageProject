using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        public List<Message> GetMessagedSenderWithInclude(int id);
        public List<Message> GetMessagedReceiverWithInclude(int id);
        public void SendMessage(Message message);
    }
}
