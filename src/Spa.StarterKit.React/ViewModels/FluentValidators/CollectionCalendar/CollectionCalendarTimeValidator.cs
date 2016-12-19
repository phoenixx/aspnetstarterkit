using FluentValidation;
using Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.CollectionCalendar
{
    public class CollectionCalendarTimeValidator : AbstractValidator<CollectionCalendarTimeViewModel>
    {
        public CollectionCalendarTimeValidator()
        {
            RuleFor(x => x.OperationalCutOffTime)
                .LessThanOrEqualTo(x => x.CutOffTime)
                .When(x => x.OperationalCutOffType == x.CutOffType && x.OperationalCutOffTime.HasValue)
                .WithMessage("If specified, operational cut off must be earlier than or the same as allocation cut off");

            RuleFor(x => (int) x.OperationalCutOffType)
                .GreaterThanOrEqualTo(x => (int) x.CutOffType)
                .When(x => x.OperationalCutOffTime.HasValue)
                .WithMessage("If specified, operational cut off must be earlier than or the same as allocation cut off");

            RuleFor(x => x.PreAdviceTime)
                .LessThanOrEqualTo(x => x.CutOffTime)
                .When(x => x.PreAdviceType == x.CutOffType && x.PreAdviceTime.HasValue)
                .WithMessage("Pre advice time must be earlier than or the same as allocation cut off.");
        }
    }
}