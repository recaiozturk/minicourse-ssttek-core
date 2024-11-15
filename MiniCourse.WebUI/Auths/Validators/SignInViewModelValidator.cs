using FluentValidation;
using MiniCourse.WebUI.Auths.ViewModels;

namespace MiniCourse.WebUI.Auths.Validators
{
    public class SignInViewModelValidator: AbstractValidator<SignInViewModel>
    {
        public SignInViewModelValidator()
        {
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Şifre boş olamaz.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

        }
    }
}
