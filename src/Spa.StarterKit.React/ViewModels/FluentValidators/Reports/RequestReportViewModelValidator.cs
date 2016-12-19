using FluentValidation;
using Spa.StarterKit.React.ViewModels.Reports;
using System.Linq;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Reports
{
    public class RequestReportViewModelValidator : AbstractValidator<RequestReportViewModel>
    {
        private const string GREATER_THAN = "'{0}' must be greater than or equal to '{1}'";
        private const string LESS_THAN = "'{0}' must be less than or equal to '{1}'";

        public RequestReportViewModelValidator()
        {
            RuleFor(x => x.Filters)
                .Must(x => (x.Carriers != null && x.Carriers.Any()) ||
                           (x.CarrierServices != null && x.CarrierServices.Any()) ||
                           x.CarrierWasLate.HasValue ||
                           x.DateCreatedFrom.HasValue ||
                           x.DateCreatedTo.HasValue ||
                           x.DateDeliveredFrom.HasValue ||
                           x.DateDeliveredTo.HasValue ||
                           x.EstimatedDeliveryDateFrom.HasValue ||
                           x.EstimatedDeliveryDateTo.HasValue ||
                           x.DateShippedFrom.HasValue ||
                           x.DateShippedTo.HasValue ||
                           x.DepthFrom.HasValue ||
                           x.DepthTo.HasValue ||
                           x.LengthFrom.HasValue ||
                           x.LengthTo.HasValue ||
                           (x.MetaDataFilters != null && x.MetaDataFilters.Any() && x.MetaDataFilters.Any(d => d.StringValuesSelected != null && d.StringValuesSelected.Any())) ||
                           (x.ShippedFroms != null && x.ShippedFroms.Any()) ||
                           (x.Statuses != null && x.Statuses.Any()) ||
                           x.ValueFrom.HasValue ||
                           x.ValueTo.HasValue ||
                           x.WeightFrom.HasValue ||
                           x.WeightTo.HasValue ||
                           x.WeWereLate.HasValue ||
                           x.WidthFrom.HasValue ||
                           x.WidthTo.HasValue)
                .WithMessage("At least one filter must be populated.");

            RuleFor(x => x.Filters.DateCreatedFrom)
                .LessThanOrEqualTo(x => x.Filters.DateCreatedTo)
                .When(x => x.Filters.DateCreatedFrom.HasValue && x.Filters.DateCreatedTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "date created from", "date created to"));

            RuleFor(x => x.Filters.DateCreatedTo)
                .GreaterThanOrEqualTo(x => x.Filters.DateCreatedFrom)
                .When(x => x.Filters.DateCreatedTo.HasValue && x.Filters.DateCreatedFrom.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "date created to", "date created from"));

            RuleFor(x => x.Filters.DateShippedFrom)
                .LessThanOrEqualTo(x => x.Filters.DateShippedTo)
                .When(x => x.Filters.DateShippedFrom.HasValue && x.Filters.DateShippedTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "date shipped from", "date shipped to"));

            RuleFor(x => x.Filters.DateShippedTo)
                .GreaterThanOrEqualTo(x => x.Filters.DateShippedFrom)
                .When(x => x.Filters.DateShippedTo.HasValue && x.Filters.DateShippedFrom.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "date shipped to", "date shipped from"));

            RuleFor(x => x.Filters.DateDeliveredFrom)
                .LessThanOrEqualTo(x => x.Filters.DateDeliveredTo)
                .When(x => x.Filters.DateDeliveredFrom.HasValue && x.Filters.DateDeliveredTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "date delivered from", "date delivered to"));

            RuleFor(x => x.Filters.DateDeliveredTo)
                .GreaterThanOrEqualTo(x => x.Filters.DateDeliveredFrom)
                .When(x => x.Filters.DateDeliveredTo.HasValue && x.Filters.DateDeliveredFrom.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "date delivered to", "date delivered from"));
            
            RuleFor(x => x.Filters.EstimatedDeliveryDateFrom)
                .LessThanOrEqualTo(x => x.Filters.EstimatedDeliveryDateTo)
                .When(x => x.Filters.EstimatedDeliveryDateFrom.HasValue && x.Filters.EstimatedDeliveryDateTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "estimated delivery date from", "estimated delivery date to"));

            RuleFor(x => x.Filters.EstimatedDeliveryDateTo)
                .GreaterThanOrEqualTo(x => x.Filters.EstimatedDeliveryDateFrom)
                .When(x => x.Filters.EstimatedDeliveryDateFrom.HasValue && x.Filters.EstimatedDeliveryDateTo.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "estimated delivery date to", "estimated delivery date from"));
            
            RuleFor(x => x.Filters.WeightFrom)
                .LessThanOrEqualTo(x => x.Filters.WeightTo)
                .When(x => x.Filters.WeightFrom.HasValue && x.Filters.WeightTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "weight from", "weight to"));

            RuleFor(x => x.Filters.WeightTo)
                .GreaterThanOrEqualTo(x => x.Filters.WeightFrom)
                .When(x => x.Filters.WeightTo.HasValue && x.Filters.WeightFrom.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "weight to", "weight from"));

            RuleFor(x => x.Filters.LengthFrom)
                .LessThanOrEqualTo(x => x.Filters.LengthTo)
                .When(x => x.Filters.LengthFrom.HasValue && x.Filters.LengthTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "length from", "length to"));

            RuleFor(x => x.Filters.LengthTo)
                .GreaterThanOrEqualTo(x => x.Filters.LengthFrom)
                .When(x => x.Filters.LengthTo.HasValue && x.Filters.LengthFrom.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "length to", "length from"));

            RuleFor(x => x.Filters.WidthFrom)
                .LessThanOrEqualTo(x => x.Filters.WidthTo)
                .When(x => x.Filters.WidthFrom.HasValue && x.Filters.WidthTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "width from", "width to"));

            RuleFor(x => x.Filters.WidthTo)
                .GreaterThanOrEqualTo(x => x.Filters.WidthFrom)
                .When(x => x.Filters.WidthTo.HasValue && x.Filters.WidthFrom.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "width to", "width from"));

            RuleFor(x => x.Filters.DepthFrom)
                .LessThanOrEqualTo(x => x.Filters.DepthTo)
                .When(x => x.Filters.DepthFrom.HasValue && x.Filters.DepthTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "depth from", "depth to"));

            RuleFor(x => x.Filters.DepthTo)
                .GreaterThanOrEqualTo(x => x.Filters.DepthFrom)
                .When(x => x.Filters.DepthTo.HasValue && x.Filters.DepthFrom.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "depth to", "depth from"));

            RuleFor(x => x.Filters.ValueFrom)
                .LessThanOrEqualTo(x => x.Filters.ValueTo)
                .When(x => x.Filters.ValueFrom.HasValue && x.Filters.ValueTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "value from", "value to"));

            RuleFor(x => x.Filters.ValueTo)
                .GreaterThanOrEqualTo(x => x.Filters.ValueFrom)
                .When(x => x.Filters.ValueTo.HasValue && x.Filters.ValueFrom.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "value to", "value from"));

            

        }
    }
}