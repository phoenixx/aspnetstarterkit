using FluentValidation;
using Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.CollectionCalendar
{
    public class AddRuleValidator : AbstractValidator<AddRuleViewModel>
    {
        public AddRuleValidator()
        {
            RuleFor(x => x.Rule).SetValidator(new CollectionCalendarTimeValidator());
        }
    }
}