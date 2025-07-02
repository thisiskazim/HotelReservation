using HotelProjectBusinessLayer.Abstract;
using HotelProjectDataAccessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectBusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TBookingStatusChangeApproved(Booking booking)
        {


            _bookingDal.BookingStatusChangeApproved(booking);
        }

        public void TBookingStatusChangeApproved2(int id)
        {
            _bookingDal.BookingStatusChangeApproved2(id);
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public Booking TGetByID(int id)
        {
          return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetList()
        {
           return _bookingDal.GetList();
        }

        public void TInsert(Booking t)
        {
            //var varMi = _bookingDal.GetList();
            //varMi.Where(p => p.BookingID = t.BookingID).FirstOrDefault();
            if (t != null && t.Checkin > t.CheckOut)
            {
                t.ErrorMessages.Add("Giriş tarihi çıkış tarihinden büyük olamaz.");
            }
            if (t.Checkin < DateTime.Now.Date)
            {
                t.ErrorMessages.Add("Giriş tarihi geçmişte olamaz.");
            }
            if (t.ErrorMessages.Any())
            {
                return; // hata var, işleme devam etme
            }
            
            _bookingDal.Insert(t);
        }

        public void TUpdate(Booking t)
        {
            _bookingDal.Update(t);
        }

        int IBookingService.TGetBookingCount()
        {
           return _bookingDal.GetBookingCount();
        }

		public List<Booking> TLast6Bookings()
		{
			return _bookingDal.Last6Bookings();
		}

      public  void  TBookingStatusChangeApproved3(int id)
        {
           _bookingDal.BookingStatusChangeApproved3(id);
        }

    public  void TBookingStatusChangeCancel(int id)
        {
            _bookingDal.BookingStatusChangeCancel(id);
        }

     public   void TBookingStatusChangeWait(int id)
        {
           _bookingDal.BookingStatusChangeWait(id);
        }
    }
}
