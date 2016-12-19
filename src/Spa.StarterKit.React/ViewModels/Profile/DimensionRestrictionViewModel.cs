using Spa.StarterKit.React.ViewModels.Profile.Enums;

namespace Spa.StarterKit.React.ViewModels.Profile
{
    public class DimensionRestrictionViewModel
    {
        public int Id { get; set; }
        public DimensionType DimensionType { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }
    }
}