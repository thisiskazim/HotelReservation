using HotelProjectBusinessLayer.Abstract;
using HotelProjectDataAccessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using HotelProjectBusinessLayer.ValidationRules;


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
            var s = new BookingValidator();
            var error = s.ValidatorsBook(t);


            if (cakisanVarMi(t))
            {
                t.ErrorMessages.Add("Aynı tarih aralığında birden fazla rezervasyon yapamazsınız.");
            }

            if (error.Any())
            {
                t.ErrorMessages = error;
                return;
            }


            _bookingDal.Insert(t);
        }

        public void TUpdate(Booking t)
        {
            var s = new BookingValidator();
            var error = s.ValidatorsBook(t);

            if (cakisanVarMi(t))
            {
                t.ErrorMessages.Add("Aynı tarih aralığında birden fazla rezervasyon yapamazsınız.");
            }

            if (error.Any())
            {
                t.ErrorMessages = error;
                return;
            }


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
        public bool cakisanVarMi(Booking t)
        {
            var bookings = _bookingDal.GetByName(t.Name);

            return bookings.Any(p =>
                p.BookingID != t.BookingID &&
                p.Checkin < t.CheckOut &&
                p.CheckOut > t.Checkin);
        }
    

    }
}
