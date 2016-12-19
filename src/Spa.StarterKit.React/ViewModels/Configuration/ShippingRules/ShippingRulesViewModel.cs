using Spa.StarterKit.React.ViewModels.Profile;

namespace Spa.StarterKit.React.ViewModels.Configuration.ShippingRules
{
    public class ShippingRulesViewModel
    {
        public ShippingRulesViewModel()
        {
            AllowedWeight = new DimensionRuleViewModel { Unit = "kg"};
            AllowedVolumetricWeight = new DimensionRuleViewModel { Unit = "kg" };
            AllowedLength = new DimensionRuleViewModel { Unit = "cm" };
            AllowedGirth = new DimensionRuleViewModel { Unit = "cm" };
            AllowedCombinedDimensions = new DimensionRuleViewModel { Unit = "cm" };
            AllowedVolume = new DimensionRuleViewModel { Unit = "cm³" };
            CompensationAndValue = new CompensationAndValueViewModel();
            GeographicAvailability = new GeographicAvailabilityViewModel();
        }

        public DimensionRuleViewModel AllowedWeight { get; set; }
        public DimensionRuleViewModel AllowedVolumetricWeight { get; set; }
        public DimensionRuleViewModel AllowedLength { get; set; }
        public DimensionRuleViewModel AllowedGirth { get; set; }
        public DimensionRuleViewModel AllowedCombinedDimensions { get; set; }
        public DimensionRuleViewModel AllowedVolume { get; set; }

        public CompensationAndValueViewModel CompensationAndValue { get; set; }

        public GeographicAvailabilityViewModel GeographicAvailability { get; set; }
    }
}