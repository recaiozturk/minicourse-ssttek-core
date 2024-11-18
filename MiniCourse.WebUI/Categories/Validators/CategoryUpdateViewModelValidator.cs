using FluentValidation;
using MiniCourse.WebUI.Categories.ViewModels;

namespace MiniCourse.WebUI.Categories.Validators
{
    public class CategoryUpdateViewModelValidator : AbstractValidator<CategoryUpdateViewModel>
    {
        public CategoryUpdateViewModelValidator()
        {
            RuleFor(x => x.Name)
                        .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                        .MinimumLength(5).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
        }
    }
}
