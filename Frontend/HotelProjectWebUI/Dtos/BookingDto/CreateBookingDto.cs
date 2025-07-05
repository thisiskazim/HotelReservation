using System;
using HotelProjectEntityLayer.Concrete;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


namespace HotelProjectWebUI.Dtos.BookingDto
{
    public class CreateBookingDto:BaseEntity
    {
        public int BookingID { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen ad yazınız")]
        public string Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen maili yazınız")]
        public string Mail { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen giriş tarihinizi yazınız")]
        [DataType(DataType.Date)]
        public DateTime? Checkin { get; set; }
        [DataType(DataType.Date)]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen çıkış tarihinizi yazınız")]////USİNG OLARAK EKLESEM DE REQUİRED İ KABUL ETMEDİ BÖYLE YAZMAK ZORUNDA KALDIM ŞİMDİLİK
        public DateTime? CheckOut { get; set; }
      
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen yetişkin sayısını yazınız")]
        public string AdultCount { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen çocuk sayısını yazınız")]
        public string ChildCount { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen oda sayısını yazınız")]
        public string RoomCount { get; set; }
        public string SpecialRequest { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
