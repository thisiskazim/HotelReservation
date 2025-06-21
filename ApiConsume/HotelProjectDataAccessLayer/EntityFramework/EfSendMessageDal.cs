using HotelProjectDataAccessLayer.Abstract;
using HotelProjectDataAccessLayer.Concrete;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDataAccessLayer.EntityFramework
{
    public class EfSendMessageDal : GenericRepository<SendMessage>,ISendMessageDal
    {
        public EfSendMessageDal(Context context) : base(context)
        {

        }

        public int GetSendMessageCount()
        {
           var context= new Context();
            return context.SendMessages.Count();
        }
    }
}
