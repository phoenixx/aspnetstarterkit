using FluentValidation;
using Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.CollectionCalendar
{
    public class AddExceptionValidator : AbstractValidator<AddExceptionViewModel>
    {
        public AddExceptionValidator()
        {
            RuleFor(x => x.Exception).SetValidator(new CollectionCalendarExceptionValidator());
        }
    }
}