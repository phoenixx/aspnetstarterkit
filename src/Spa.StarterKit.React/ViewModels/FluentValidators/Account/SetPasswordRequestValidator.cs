using System;
using FluentValidation;
using Spa.StarterKit.React.Config;
using Spa.StarterKit.React.ViewModels.User;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Account
{
	public class SetPasswordRequestValidator : AbstractValidator<SetPasswordRequest>
	{
		public SetPasswordRequestValidator()
		{
			RuleFor(model => model.AccountReference)
				.Must(value => value != Guid.Empty)
				.WithMessage("Invalid account provided");

			RuleFor(x => x.NewPassword)
				.Matches(Constants.Passwords.VALIDATION_REGEX)
				.When(x => x.NewPassword.Length > 0)
				.WithMessage(Constants.Passwords.VALIDATION_ERROR_MESSAGE);

			RuleFor(x => x.NewPassword)
				.Equal(x => x.ConfirmNewPassword)
				.When(x => x.NewPassword.Length > 0)
				.WithMessage("Passwords must match");
		}
	}
}