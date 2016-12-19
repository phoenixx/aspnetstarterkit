using System;
using FluentValidation;
using Spa.StarterKit.React.ViewModels.Shared.Payment;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Shared
{
    public class CardDetailsValidator : AbstractValidator<CardDetailsViewModel>
    {
        public CardDetailsValidator()
        {
            RuleFor(x => x.CardType).NotEmpty().WithMessage("Please select a card type");

            RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Please enter the card number");

            RuleFor(x => x.CardNumber)
                .Length(12, 19)
                .WithMessage("Your card number should be between 12 and 19 digits long");

            RuleFor(x => x.NameOnCard).NotEmpty().WithMessage("Please enter the name as it appears on the card");

            RuleFor(x => x.SecurityNumber).NotEmpty().WithMessage("Please enter a security number");

            RuleFor(x => x.SecurityNumber)
                .Length(3, 4)
                .WithMessage("The security number must be between 3 and 4 digits");

            RuleFor(x => x.FromMonth).NotEmpty().WithMessage("Please choose a valid from month");
            RuleFor(x => x.FromYear).NotEmpty().WithMessage("Please choose a valid from year");

            RuleFor(x => x.FromMonth).Must((model, fromMonth) =>
            {
                var currentYear = DateTime.Now.Year;
                int validFromYearInt;

                if (!int.TryParse(model.FromYear, out validFromYearInt))
                {
                    return false;
                }

                if (validFromYearInt < currentYear)
                {
                    return true;
                }

                if (validFromYearInt > currentYear)
                {
                    return false;
                }

                if (validFromYearInt == currentYear)
                {
                    //month must be current or below
                    int validFromMonth;
                    if (!int.TryParse(fromMonth, out validFromMonth))
                    {
                        return false;
                    }

                    if (validFromMonth > DateTime.Now.Month)
                    {
                        return false;
                    }
                }
                return true;
            }).WithMessage("The valid from date cannot be in the future.");

            RuleFor(model => model.ExpiresMonth).Must((model, toMonth) =>
            {
                var currentYear = DateTime.Now.Year;
                int validToYearInt;

                if (!int.TryParse(model.ExpiresYear, out validToYearInt))
                {
                    return false;
                }

                if (validToYearInt > currentYear)
                {
                    return true;
                }

                if (validToYearInt < currentYear)
                {
                    return false;
                }

                if (validToYearInt == currentYear)
                {
                    //month must be current or greater
                    int validToMonth;
                    if (!int.TryParse(toMonth, out validToMonth))
                    {
                        return false;
                    }
                    if (validToMonth < DateTime.Now.Month)
                    {
                        return false;
                    }
                }
                return true;
            }).WithMessage("The valid to date cannot be in the past.");
        }
    }
}