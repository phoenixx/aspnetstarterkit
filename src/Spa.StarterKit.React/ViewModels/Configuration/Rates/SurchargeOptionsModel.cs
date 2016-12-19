using Spa.StarterKit.React.ViewModels.Configuration.Rates.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
    public class SurchargeOptionsModel
    {
        public CalculationModel CalculationModel { get; set; }
        public string Dimension { get; set; }
        public int DimensionUnitId { get; set; }
        public string Description { get; set; }
        public SurchargeModelType ModelType { get; set; }
        public SurchargeLevel Level { get; set; }
        public int Id { get; set; }
    }
}