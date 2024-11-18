using FluentValidation;
using MiniCourse.WebUI.Courses.ViewModels;

namespace MiniCourse.WebUI.Courses.Validators
{
    public class CourseUpdateViewModelValidator : AbstractValidator<CourseUpdateViewModel>
    {
        public CourseUpdateViewModelValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Kurs ismi gereklidir");
            RuleFor(x => x.Title)
            .MinimumLength(2).WithMessage("Kurs ismi en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Kurs ismi en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description).NotNull().WithMessage("Kurs açıklaması gereklidir");
            RuleFor(x => x.Description)
            .MinimumLength(10).WithMessage("Kurs açıklaması en az 10 karakter olmalıdır.")
            .MaximumLength(1000).WithMessage("Kurs açıklaması fazla 1000 karakter olabilir.");

            RuleFor(x => x.Price).NotNull().WithMessage("Kurs Fiyatı gereklidir");
            RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Sayfa sayısı 0 dan büyük olmadlıdır.")
            .ScalePrecision(2, 18).WithMessage("Kurs fiyatı geçerli bir ondalık sayı olmalıdır.");

            RuleFor(x => x.CategoryId)
            .NotNull().WithMessage("kategori Seçiniz")
            .NotEmpty().WithMessage("kategori Seçiniz")
            .GreaterThan(0).WithMessage("Geçerli bir kategori seçiniz");


            //RuleFor(x => x.ImageFile)
            //    .NotNull().WithMessage("Bir resim dosyası yüklemeniz gerekmektedir.")
            //    .Must(file => file.Length > 0).WithMessage("Bir resim dosyası yüklemeniz gerekmektedir.");
        }
    }
}
