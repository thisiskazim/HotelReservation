using System.ComponentModel.DataAnnotations;

namespace HotelProjectWebUI.Dtos.StaffDto
{
    public class ResultStaffDto
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
