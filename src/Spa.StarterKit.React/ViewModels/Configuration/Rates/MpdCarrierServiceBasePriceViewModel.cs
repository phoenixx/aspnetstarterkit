using Spa.StarterKit.React.Extensions;
using Spa.StarterKit.React.ViewModels.Configuration.Rates.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
    public class MpdCarrierServiceBasePriceViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public PriceModelLevel Level { get; set; }
        public PriceModelType Type { get; set; }
        public int VolumetricFactor { get; set; }
        public CalculationModel CalculationModel { get; set; }
        public DataSource DataSource { get; set; }
        public int PriceCount { get; set; }
        public bool UsingDefaultVolumetricFactor { get; set; }
        public int BehaviourChecksum { get; set; }
        public int EquivalentCostModelId { get; set; }

        public string DataSourceDescription => DataSource.ToDescription();

        public WeightCalculation WeightCalculation
        {
            get
            {
                switch (Type)
                {
                    case PriceModelType.AbsoluteWeight:
                    case PriceModelType.AbsoluteWeightCollectionPostcodeVolume:
                    case PriceModelType.AbsoluteWeightTiered:
                        return WeightCalculation.Absolute;
                    case PriceModelType.Distance:
                        return WeightCalculation.Distance;
                    default:
                        return WeightCalculation.Volumetric;
                }
            }
        }
    }
}