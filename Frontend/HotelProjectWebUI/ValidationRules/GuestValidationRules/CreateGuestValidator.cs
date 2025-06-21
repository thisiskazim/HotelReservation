using FluentValidation;
using HotelProjectWebUI.Dtos.GuestDto;

namespace HotelProjectWebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim alanı boş gecilemez");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soyisim alanı boş gecilemez");
            RuleFor(x=>x.City).NotEmpty().WithMessage("Şehir alanı boş gecilemez");
            RuleFor(x=>x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x=>x.Surname).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x=>x.City).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x=>x.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapınız");
            RuleFor(x=>x.Surname).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapınız");
            RuleFor(x=>x.City).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapınız");
   
        }
    }
}
