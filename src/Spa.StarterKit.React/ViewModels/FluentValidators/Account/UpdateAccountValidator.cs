using FluentValidation;
using Spa.StarterKit.React.ViewModels.Shared.Account;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Account
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountViewModel>
    {
        public UpdateAccountValidator()
        {
            RuleFor(x => x.Roles).Must(x => x.Count > 0).WithMessage("A user must have at least one role.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please enter a first name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please enter a last name");
        }
    }
}