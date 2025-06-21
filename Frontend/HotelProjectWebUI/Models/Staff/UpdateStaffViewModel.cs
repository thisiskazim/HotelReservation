using System.ComponentModel.DataAnnotations;

namespace HotelProjectWebUI.Models.Staff
{
    public class UpdateStaffViewModel
    {
        [Key]
        public int StafID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SocialMedia1 { get; set; }
        public string SocialMedia2 { get; set; }
        public string SocialMedia3 { get; set; }
    }
}
