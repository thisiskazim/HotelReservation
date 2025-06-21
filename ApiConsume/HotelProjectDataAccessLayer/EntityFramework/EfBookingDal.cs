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
    public class EfBookingDal      :GenericRepository<Booking> ,IBookingDal
    {

        public EfBookingDal(Context context) : base(context)
        {

        }

        public void BookingStatusChangeApproved(Booking booking)
        {
            var   context = new Context();
           var values= context.Bookings.Where(X=>X.BookingID==booking.BookingID).FirstOrDefault();
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeApproved2(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
              var context = new Context();
            var values =context.Bookings.Count();
            return values;
        }

		 public List<Booking> Last6Bookings()
		{
			var context = new Context();
            var values =context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
            return values;
		}

     public   void  BookingStatusChangeApproved3(int id)
        {
          var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();

        }

       public void BookingStatusChangeCancel(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "İptal Edildi";
            context.SaveChanges();

        }

     public void BookingStatusChangeWait(int id)
        {

            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Müşteri Aranacak";
            context.SaveChanges();

        }
    }
}
