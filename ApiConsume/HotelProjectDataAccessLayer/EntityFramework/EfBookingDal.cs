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
    public class EfBookingDal:GenericRepository<Booking> ,IBookingDal
    {

        private readonly Context _context;

        public EfBookingDal(Context context):base(context)
        {
            _context = context;
        }


        public void BookingStatusChangeApproved(Booking booking)
        {
            
           var values= _context.Bookings.Where(X=>X.BookingID==booking.BookingID).FirstOrDefault();
           if (values != null)
           {
               values.Status = "Onaylandı";
               _context.SaveChanges();
           }
        
        }

        public void BookingStatusChangeApproved2(int id)
        {
            
            var values = _context.Bookings.Find(id);
            if (values != null)
            {
                values.Status = "Onaylandı";
                _context.SaveChanges();
            }
          
        }

        public int GetBookingCount()
        {
              
            var values =_context.Bookings.Count();
            return values;
        }

		 public List<Booking> Last6Bookings()
		{
			
            var values =_context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
            return values;
		}

     public   void  BookingStatusChangeApproved3(int id)
        {
          
            var values = _context.Bookings.Find(id);
            if (values != null)
            {
                values.Status = "Onaylandı";
                _context.SaveChanges();
            }
           

        }

       public void BookingStatusChangeCancel(int id)
        {
            var values = _context.Bookings.Find(id);

            if (values != null)
            {
                 values.Status = "İptal Edildi";
                _context.SaveChanges();
            }

        }

     public void BookingStatusChangeWait(int id)
        {

            
            var values = _context.Bookings.Find(id);
            if (values != null)
            {
                values.Status = "Müşteri Aranacak";
                _context.SaveChanges();
            }

        }
    }
}
