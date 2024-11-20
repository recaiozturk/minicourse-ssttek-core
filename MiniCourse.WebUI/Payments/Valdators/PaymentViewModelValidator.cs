using FluentValidation;
using MiniCourse.WebUI.Payments.ViewModels;

namespace MiniCourse.WebUI.Payments.Valdators
{
    public class PaymentViewModelValidator: AbstractValidator<PaymentViewModel>
    {
        public PaymentViewModelValidator()
        {

            RuleFor(p => p.NameForBill)
                .NotNull().WithMessage("Kurs ismi gereklidir")
                .NotEmpty()
                .WithMessage("Fatura için isim gereklidir.")
                .MaximumLength(50)
                .WithMessage("İsim en fazla 50 karakter olabilir.");

            RuleFor(p => p.LastNameForBill)
                .NotEmpty()
                .WithMessage("Fatura için soyisim gereklidir.")
                .MaximumLength(50)
                .WithMessage("Soyisim en fazla 50 karakter olabilir.");

            RuleFor(p => p.AdressForBill)
                .NotEmpty()
                .WithMessage("Fatura için adres gereklidir.")
                .MaximumLength(200)
                .WithMessage("Adres en fazla 200 karakter olabilir.");

            RuleFor(p => p.CardHolderName)
                .NotEmpty()
                .WithMessage("Kart sahibi adı gereklidir.")
                .MaximumLength(100)
                .WithMessage("Kart sahibi adı en fazla 100 karakter olabilir.");

            RuleFor(p => p.CardNumber)
                .NotEmpty()
                .WithMessage("Kart numarası gereklidir.")
                .MaximumLength(16)
                .MaximumLength(16)
                .WithMessage("Geçerli bir kart numarası giriniz.");

            RuleFor(p => p.ExpiryDate)
                .NotEmpty()
                .WithMessage("Son kullanma tarihi gereklidir.")
                .Matches(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$")
                .WithMessage("Son kullanma tarihi MM/YY formatında olmalıdır.");

            RuleFor(p => p.CVV)
                .NotEmpty()
                .WithMessage("Güvenlik kodu (CVV) gereklidir.")
                .Length(3)
                .WithMessage("CVV, 3 haneli bir sayı olmalıdır.")
                .Matches(@"^\d{3}$")
                .WithMessage("CVV yalnızca rakamlardan oluşmalıdır.");
        }
    }
}
