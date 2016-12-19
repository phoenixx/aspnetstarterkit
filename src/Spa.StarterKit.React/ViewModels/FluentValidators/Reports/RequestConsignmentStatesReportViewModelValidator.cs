using System;
using FluentValidation;
using Spa.StarterKit.React.ViewModels.Reports;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Reports
{
    public class RequestConsignmentStatesReportViewModelValidator : AbstractValidator<RequestConsignmentStatesReportViewModel>
    {
        private const int MaxReportDateRangeInDays = 90;
        private const string GREATER_THAN = "'{0}' must be greater than or equal to '{1}'";
        private const string LESS_THAN = "'{0}' must be less than or equal to '{1}'";

        public RequestConsignmentStatesReportViewModelValidator()
        {
            RuleFor(x => x.ReportFrom)
                .LessThanOrEqualTo(x => x.ReportTo)
                .WithMessage(string.Format(LESS_THAN, "report from", "report to"));

            RuleFor(x => x.ReportFrom)
                .GreaterThanOrEqualTo(x => new DateTime(2016, 1, 1, 0, 0, 0))
                .WithMessage(string.Format(GREATER_THAN, "report from", "1st January 2016"));

            RuleFor(x => x.ReportTo)
                .GreaterThanOrEqualTo(x => x.ReportFrom)
                .WithMessage(string.Format(GREATER_THAN, "report to", "report from"));

            RuleFor(x => x.ReportTo)
                .GreaterThanOrEqualTo(x => new DateTime(2016, 1, 1, 0, 0, 0))
                .WithMessage(string.Format(GREATER_THAN, "report to", "1st January 2016"));

            RuleFor(x => x.ReportFrom)
                .Must((model, field) => Math.Abs((model.ReportTo - model.ReportFrom).Days) <= MaxReportDateRangeInDays)
                .WithMessage($"Selected date range cannot exceed {MaxReportDateRangeInDays} days");

            RuleFor(x => x.ReportTo)
                .Must((model, field) => Math.Abs((model.ReportTo - model.ReportFrom).Days) <= MaxReportDateRangeInDays)
                .WithMessage($"Selected date range cannot exceed {MaxReportDateRangeInDays} days");

            RuleFor(x => x.EstimatedDeliveryDateFrom)
                .LessThanOrEqualTo(x => x.EstimatedDeliveryDateTo)
                .When(x => x.EstimatedDeliveryDateFrom.HasValue && x.EstimatedDeliveryDateTo.HasValue)
                .WithMessage(string.Format(LESS_THAN, "estimated delivery date from", "estimated delivery date to"));

            RuleFor(x => x.EstimatedDeliveryDateTo)
                .GreaterThanOrEqualTo(x => x.EstimatedDeliveryDateFrom)
                .When(x => x.EstimatedDeliveryDateFrom.HasValue && x.EstimatedDeliveryDateTo.HasValue)
                .WithMessage(string.Format(GREATER_THAN, "estimated delivery date to", "estimated delivery date from"));
        }
    }
}