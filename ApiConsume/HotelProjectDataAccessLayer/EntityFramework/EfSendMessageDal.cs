using HotelProjectDataAccessLayer.Abstract;
using HotelProjectDataAccessLayer.Concrete;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;
using System.Linq;


namespace HotelProjectDataAccessLayer.EntityFramework
{
    public class EfSendMessageDal : GenericRepository<SendMessage>,ISendMessageDal
    {
        private readonly Context _context;

        public EfSendMessageDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GetSendMessageCount()
        {
            return _context.SendMessages.Count();
        }
    }
}
