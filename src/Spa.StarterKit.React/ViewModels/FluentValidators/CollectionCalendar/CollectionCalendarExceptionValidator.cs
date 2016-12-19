using FluentValidation;
using Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.CollectionCalendar
{
    public class CollectionCalendarExceptionValidator : AbstractValidator<CollectionCalendarExceptionViewModel>
    {
        public CollectionCalendarExceptionValidator()
        {
            RuleFor(x => x.CarrierCollection).SetValidator(new CollectionCalendarTimeValidator());
        }
    }
}