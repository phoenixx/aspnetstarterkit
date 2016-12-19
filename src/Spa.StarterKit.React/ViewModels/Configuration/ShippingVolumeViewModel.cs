namespace Spa.StarterKit.React.ViewModels.Configuration
{
    public class ShippingVolumeViewModel
    {
        public ShippingLocationViewModel ShippingLocation { get; set; }
        public int? MondayVolume { get; set; }
        public int? TuesdayVolume { get; set; }
        public int? WednesdayVolume { get; set; }
        public int? ThursdayVolume { get; set; }
        public int? FridayVolume { get; set; }
        public int? SaturdayVolume { get; set; }
        public int? SundayVolume { get; set; }
    }
}