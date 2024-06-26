using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFrameWork
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        Context c=new Context();

        public List<Message> GetMessagedReceiverWithInclude(int id)
        {
            var x = c.Messages.Where(x => x.ReceiverId == id).Include(x => x.Sender).Include(x => x.Receiver).ToList();
            return x;
        }

        public List<Message> GetMessagedSenderWithInclude(int id)
        {
            var x = c.Messages.Where(x => x.SenderId == id).Include(x => x.Sender).Include(x => x.Receiver).ToList();
            return x;
        }

        public void SendMessage(Message message)
        {
            c.Messages.Add(message);
            c.SaveChanges();
        }
    }
}
