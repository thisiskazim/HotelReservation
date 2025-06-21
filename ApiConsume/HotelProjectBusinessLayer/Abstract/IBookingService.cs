using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectBusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {

        void TBookingStatusChangeApproved(Booking booking);
        void TBookingStatusChangeApproved2(int id);
        int TGetBookingCount();
        List<Booking> TLast6Bookings();
        void TBookingStatusChangeApproved3(int id);
        void TBookingStatusChangeCancel(int id);
        void TBookingStatusChangeWait(int id);

    }
}
