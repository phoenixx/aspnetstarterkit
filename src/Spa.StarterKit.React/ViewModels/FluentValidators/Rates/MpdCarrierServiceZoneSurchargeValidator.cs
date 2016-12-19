using FluentValidation;
using Spa.StarterKit.React.ViewModels.Configuration.Rates;
using Spa.StarterKit.React.ViewModels.Configuration.Rates.Enums;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Rates
{
    public class MpdCarrierServiceZoneSurchargeValidator : MpdCarrierServiceSurchargeValidator<MpdCarrierServiceZoneSurchargeViewModel>
    {
        public MpdCarrierServiceZoneSurchargeValidator()
        {
            When(x => x.EndpointInvolvement == EndpointInvolvement.Collection, () =>
                {
                    RuleFor(x => x.CollectionZoneId).NotEmpty().WithMessage("Collection Zone is required");
                });

            When(x => x.EndpointInvolvement == EndpointInvolvement.Delivery, () =>
            {
                RuleFor(x => x.DeliveryZoneId).NotEmpty().WithMessage("Delivery Zone is required");
            });

            When(x => x.EndpointInvolvement == EndpointInvolvement.Either, () =>
            {
                RuleFor(x => x.CollectionZoneId).NotEmpty().WithMessage("Collection Zone is required");
                RuleFor(x => x.DeliveryZoneId).NotEmpty().WithMessage("Delivery Zone is required");
                RuleFor(x => x.DeliveryZoneId).Equal(x => x.CollectionZoneId).WithMessage("Collection and Delivery zone must be the same");
            });

            When(x => x.EndpointInvolvement == EndpointInvolvement.Both, () =>
            {
                RuleFor(x => x.CollectionZoneId).NotEmpty().WithMessage("Collection Zone is required");
                RuleFor(x => x.DeliveryZoneId).NotEmpty().WithMessage("Delivery Zone is required");
            });

        }
    }
}