using System.ComponentModel.DataAnnotations;

namespace HotelProjectWebUI.Models.Staff
{
    public class StaffViewModel
    {
        [Key]
        public int StafID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
   
    }
}
