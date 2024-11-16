using FluentValidation;
using MiniCourse.WebUI.Members.ViewModels;
using MiniCourse.WebUI.Roles.ViewModels;

namespace MiniCourse.WebUI.Members.Validators
{
    public class MemberUpdateViewModelValidator : AbstractValidator<MemberProfileUpdateViewModel>
    {
        public MemberUpdateViewModelValidator()
        {
            RuleFor(x => x.UserName)
                        .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                        .MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakter olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir ismi boş olamaz.")
                .MinimumLength(3).WithMessage("Şehir ismi en az 3 karakter olmalidir.");
        }
    }
}
