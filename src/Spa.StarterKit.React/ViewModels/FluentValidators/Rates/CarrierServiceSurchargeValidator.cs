using System;
using FluentValidation;
using Spa.StarterKit.React.ViewModels.Configuration.Rates;
using Spa.StarterKit.React.ViewModels.Configuration.Rates.Enums;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Rates
{
    public class CarrierServiceSurchargeValidator : AbstractValidator<CarrierServiceSurchargeViewModel>
    {
        private const int DAY_OF_WEEK_UNIT_ID = 7;
        private const int NOT_APPLICABLE_DIMENSIONS_ID = 1;

        public CarrierServiceSurchargeValidator()
        {
            //Common
            RuleFor(x => x.Reference).NotEmpty().WithMessage("Please enter a reference");
            RuleFor(x => x.Label).NotEmpty().WithMessage("Please enter a name");
            RuleFor(x => x.CurrencyIsoCode).NotEmpty().WithMessage("Please enter a currency");

            //Dimensions
            RuleFor(x => x.DimensionUnitId).NotEmpty().WithMessage("Please enter the dimension unit");

            When((x => x.DimensionUnitId != DAY_OF_WEEK_UNIT_ID && x.DimensionUnitId != NOT_APPLICABLE_DIMENSIONS_ID), () =>
            {
                RuleFor(x => x.DimensionIntervalStart)
                    .NotEmpty().WithMessage("The dimension start is required")
                    .GreaterThan(0).WithMessage("The dimension start must be greater than zero");

                
                When(x => x.DimensionIntervalEnd.HasValue, () =>
                {
                    RuleFor(x => x.DimensionIntervalEnd).GreaterThan(0).WithMessage("The dimension end must be greater than zero");
                    RuleFor(x => x.DimensionIntervalEnd).GreaterThan(x => x.DimensionIntervalStart).WithMessage("The dimension end must be greater than the start");
                });
                
            });

            //Model
            RuleFor(x => x.CarrierServiceSurchargeModel).SetValidator(new CarrierServiceSurchargeModelViewModelValidator());

            //Dates
            //RuleFor(x => x.ValidFrom).GreaterThanOrEqualTo(DateTime.Today).WithMessage("The start date must not be in the past");
            When (x=>x.ValidTo.HasValue, () => {
                                                   RuleFor(x => x.ValidTo).GreaterThan(DateTime.Now).WithMessage("The end date must not be in the past");
            });

            //Fixed surcharges
            When(x=>x.CalculationModel == CalculationModel.Fixed, () =>
            {
                RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Price must be greater than zero");
                RuleFor(x => x.IncrementalUnitFactor.HasValue).Equal(false).WithMessage("Incremental Unit Factor property is only applicable for Calculated Surcharges");
                RuleFor(x => x.IncrementalUnitPrice.HasValue).Equal(false).WithMessage("Incremental Unit Price property is only applicable for Calculated Surcharges");
                RuleFor(x => x.MinimumAmount.HasValue).Equal(false).WithMessage("Minimum Price property is only applicable for Calculated Surcharges");
                RuleFor(x => x.MaximumAmount.HasValue).Equal(false).WithMessage("Maximum Price property is only applicable for Calculated Surcharges");
            });

            //Calculated surcharges
            When(x => x.CalculationModel == CalculationModel.Calculated, () =>
            {
                RuleFor(x => x.UseMargin).Equal(false).WithMessage("Margin can only be used with fixed rates.");
                RuleFor(x => x.IncrementalUnitFactor).GreaterThan(0).WithMessage("Incremental Unit Factor must be greater than zero");
                RuleFor(x => x.IncrementalUnitPrice).GreaterThan(0).WithMessage("Incremental Unit Price must be greater than zero");
                RuleFor(x => x.MinimumAmount).GreaterThanOrEqualTo(0).WithMessage("Minimum Price must be greater than or equal to zero");
                RuleFor(x => x.MaximumAmount)
                    .GreaterThanOrEqualTo(0).WithMessage("Maximum Price must be greater than or equal to zero").When(x => x.MinimumAmount.HasValue)
                    .GreaterThan(x => x.MinimumAmount.Value).WithMessage("The Maximum Price must be greater than the Minimum Price").When(x => x.MinimumAmount.HasValue);
            });

            //Margin based surcharges
            When(x => x.UseMargin, () =>
            {
                RuleFor(x => x.Margin).GreaterThan(0).WithMessage("Margin must be greater than zero");
            });
            When(x => x.UseMargin == false, () =>
            {
                RuleFor(x => x.Margin.HasValue).Equal(false).WithMessage("Margin property is only applicable for Margin based Surcharges");
            });


            //Fuel surcharges
            When(x => x.CarrierServiceSurchargeModel.Type == SurchargeModelType.Fuel, () =>
            {
                RuleFor(x => x.Amount).InclusiveBetween(0, 100).WithMessage("Fuel surcharge must be between 0 and 100%");
            });

            //Days of week
            When(x => x.CarrierServiceSurchargeModel.Type == SurchargeModelType.SpecificDayCollection 
                      || x.CarrierServiceSurchargeModel.Type== SurchargeModelType.SpecificDayDelivery, () =>
                      {
                          RuleFor(x => x.DimensionIntervalStart).InclusiveBetween(0, 6).WithMessage("Dimension start must be a day of the week");
                          RuleFor(x => x.DimensionIntervalEnd).InclusiveBetween(0, 6).WithMessage("Dimension end must be a day of the week");
                      });

            //Consignment value
            When(x => x.CarrierServiceSurchargeModel.Type == SurchargeModelType.ConsignmentValue, () =>
            {
                RuleFor(x => x.DimensionIntervalStart).NotEmpty().WithMessage("The consignment value must be greater than zero");
            });
        }
    }
}