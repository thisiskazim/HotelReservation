using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProjectEntityLayer.Concrete;

namespace HotelProjectBusinessLayer.ValidationRules
{
    public class BookingValidator
    {
        public List<string> ValidatorsBook(Booking t)
        {
            if (t != null && t.Checkin > t.CheckOut)
            {
                t.ErrorMessages.Add("Giriş tarihi çıkış tarihinden büyük olamaz.");
            }
            if (t.Checkin < DateTime.Now.Date)
            {
                t.ErrorMessages.Add("Giriş tarihi geçmişte olamaz.");
            }
         

            return t.ErrorMessages;
        }

    }
}
