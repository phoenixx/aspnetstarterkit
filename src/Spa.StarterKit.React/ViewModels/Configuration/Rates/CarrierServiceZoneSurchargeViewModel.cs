using FluentValidation.Attributes;
using Spa.StarterKit.React.ViewModels.Configuration.Rates.Enums;
using Spa.StarterKit.React.ViewModels.FluentValidators.Rates;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
    [Validator(typeof(CarrierServiceZoneSurchargeValidator))]
    public class CarrierServiceZoneSurchargeViewModel : CarrierServiceSurchargeViewModel
    {
        /// <summary>
        /// Gets or sets the endpoint involvement.
        /// 
        /// Collection - Surcharge applies when collecting from the CollectionZone regardless of the destination.
        /// Delivery - Surcharge applies when delivering to the DeliveryZone regardless of the origin.
        /// Both - Surcharge applies when collecting from the specified CollectionZone AND delivering to the specified DeliveryZone.
        /// Either - Surcharge applies when collecting from the specified CollectionZone OR delivering to the specified DeliveryZone.
        ///
        /// </summary>
        /// <value>
        /// The endpoint involvement.
        /// </value>
        public EndpointInvolvement EndpointInvolvement { get; set; }

        public string CollectionZone { get; set; }

        public string DeliveryZone { get; set; }

        public int? CollectionZoneId { get; set; }

        public int? DeliveryZoneId { get; set; }
    }
}