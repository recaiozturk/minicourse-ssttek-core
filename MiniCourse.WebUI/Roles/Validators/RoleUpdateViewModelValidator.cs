using FluentValidation;
using MiniCourse.WebUI.Roles.ViewModels;

namespace MiniCourse.WebUI.Roles.Validators
{
    public class RoleUpdateViewModelValidator : AbstractValidator<RoleUpdateViewModel>
    {
        public RoleUpdateViewModelValidator()
        {
            RuleFor(x => x.Name)
                        .NotEmpty().WithMessage("Rol adı boş olamaz.")
                        .MinimumLength(3).WithMessage("Rol adı en az 3 karakter olmalıdır.");

        }
    }
}
