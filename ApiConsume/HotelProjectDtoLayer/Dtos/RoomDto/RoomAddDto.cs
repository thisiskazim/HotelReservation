using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDtoLayer.Dtos.RoomDto
{
    public class RoomAddDto
    {

        [Required(ErrorMessage ="Lütfen oda numarasını yazınız")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen Fiyat bilgisi yazınız")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen Oda Başlığı yazınız")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen Yatak Sayısı  yazınız")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen Banyo sayısı yazınız")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
