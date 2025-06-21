using System.ComponentModel.DataAnnotations;

namespace HotelProjectWebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad Alanı Gereklidir")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Soyad Alanı Gereklidir")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Gereklidir")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Mail  Alanı  Gereklidir")]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Şifre Alanı Gereklidir")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar Alanı Gereklidir")]
        public string ConfirmPassword { get; set; }
  
    }
}
