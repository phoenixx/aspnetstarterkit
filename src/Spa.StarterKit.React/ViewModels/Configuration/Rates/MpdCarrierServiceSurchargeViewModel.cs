using System;
using FluentValidation.Attributes;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Enums;
using Spa.StarterKit.React.ViewModels.Configuration.Rates.Enums;
using Spa.StarterKit.React.ViewModels.FluentValidators.Rates;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
    [Validator(typeof(MpdCarrierServiceSurchargeValidator<MpdCarrierServiceSurchargeViewModel>))]
    public class MpdCarrierServiceSurchargeViewModel
    {
        public string ServiceType => "MpdCarrierService";

        public bool Deleted { get; set; }

        public string Label { get; set; }

        public string Reference { get; set; }

        public string Description { get; set; }

        public int DimensionUnitId { get; set; }

        public string Dimension { get; set; }

        public string CurrencyIsoCode { get; set; }

        /// <summary>
        /// Gets or sets the dimension interval start.
        /// The minimum end of the range for which this surcharge applies
        /// </summary>
        /// <value>
        /// The dimension interval start.
        /// </value>
        public decimal DimensionIntervalStart { get; set; }

        /// <summary>
        /// Gets or sets the dimension interval end.
        /// The maximum end of the range for which this surcharge applies.
        /// </summary>
        /// <value>
        /// The dimension interval end.
        /// </value>
        public decimal? DimensionIntervalEnd { get; set; }

        /// <summary>
        /// Gets or sets the calculation model, either a fixed or calculated rate.
        /// </summary>
        /// <value>
        /// The calculation model.
        /// </value>
        public CalculationModel CalculationModel { get; set; }

        /// <summary>
        /// Gets or sets the type - Additive or Variable
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public SurchargeType Type { get; set; }

        /// <summary>
        /// Gets or sets the surcharge amount - either a fixed monetary value or a percentage, where 10% = 0.1 etc.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Amount { get; set; }

        public MpdCarrierServiceSurchargeModelViewModel MpdCarrierServiceSurchargeModel { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        /// <summary>
        /// Gets or sets the type of the application - standard surcharge or retrospective (eg failed delivery).
        /// </summary>
        /// <value>
        /// The type of the application.
        /// </value>
        public ApplicationType ApplicationType { get; set; }

        #region Calculated Surcharges

        /// <summary>
        /// Gets or sets the incremental unit factor.
        /// The unit factor for which the price multiplier applies.
        ///
        /// eg:
        ///
        /// For a calculated surcharge of £1.25 per half kilo for a parcel between 20Kg and 50Kg with a minimum charge of £5 and a maximum of £15, 
        /// set the properties as follows;
        ///
        /// CalculationModel = Calculated
        /// DimensionUnit = Kg
        /// DimensionIntervalStart = 20
        /// DimensionIntervalEnd = 50
        /// IncrementalUnitFactor = 0.5
        /// IncrementalUnitPrice = 1.25
        /// MinimumAmount = 5
        /// MaximumAmount = 15
        ///
        /// </summary>
        /// <value>
        /// The incremental unit factor.
        /// </value>
        public decimal? IncrementalUnitFactor { get; set; }

        /// <summary>
        /// Gets or sets the incremental unit price.
        /// This price per incremental unit factor.
        /// </summary>
        /// <value>
        /// The incremental unit price.
        /// </value>
        public decimal? IncrementalUnitPrice { get; set; }

        /// <summary>
        /// Applies to variable only.
        /// </summary>
        public decimal? MinimumAmount { get; set; }

        /// <summary>
        /// Applies to variable only
        /// </summary>
        public decimal? MaximumAmount { get; set; }

        public VatRateType VatRateType { get; set; }

        #endregion

        #region Margin Based Surcharges

        /// <summary>
        /// Gets or sets a value indicating whether [use margin].
        /// If set to true the margin is used and the price is ignored
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use margin]; otherwise, <c>false</c>.
        /// </value>
        public bool UseMargin { get; set; }

        /// <summary>
        /// Gets or sets the margin.
        /// </summary>
        /// <value>
        /// The margin. 20% = 0.2 etc
        /// </value>
        public decimal? Margin { get; set; }
       

        #endregion

        #region Variable Surcharges only

        /// <summary>
        /// This field is only used for variable surcharges
        /// </summary>
        public bool AppliesToBase { get; set; }

        /// <summary>
        /// This field is only used for variable surcharges
        /// </summary>
        public bool AppliesToBaseOnly { get; set; }
       

        #endregion
    }
}