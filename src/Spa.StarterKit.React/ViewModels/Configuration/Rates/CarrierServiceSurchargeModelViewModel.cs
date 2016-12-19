using Spa.StarterKit.React.Extensions;
using Spa.StarterKit.React.ViewModels.Configuration.Rates.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
    public class CarrierServiceSurchargeModelViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public bool Retrospective { get; set; }
        public SurchargeLevel Level { get; set; }

        /// <summary>
        /// Gets or sets the type - Fuel, Out of Gauge etc
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public SurchargeModelType Type { get; set; }

        public string TypeDescription
        {
            get { return Type.UnCamelCase(); }
        }

        #region For Variable Surcharges Only

        /// <summary>
        /// This field is only used for variable surcharges
        /// </summary>
        public bool AppliesToBase { get; set; }

        /// <summary>
        /// This field is only used for variable surcharges
        /// </summary>
        public bool AppliesToBaseOnly { get; set; }

        /// <summary>
        /// Applies to variable only.
        /// </summary>
        public decimal MinimumAmount { get; set; }

        /// <summary>
        /// Applies to variable only
        /// </summary>
        public decimal MaximumAmount { get; set; }

        #endregion
    }
}