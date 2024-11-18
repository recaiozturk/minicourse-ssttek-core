using FluentValidation;
using MiniCourse.WebUI.Categories.ViewModels;

namespace MiniCourse.WebUI.Categories.Validators
{
    public class CategoryCreateViewModelValidator:AbstractValidator<CategoryCreateViewModel>
    {
        public CategoryCreateViewModelValidator()
        {
            RuleFor(x => x.Name)
                        .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                        .MinimumLength(5).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
        }
    }
}
