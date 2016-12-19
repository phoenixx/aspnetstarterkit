namespace Spa.StarterKit.React.ViewModels.Dashboard
{
    /// <summary>
    /// To be populated with properties to create dashboard radial chart
    /// Currently work in progress
    /// </summary>
    public class RadialItemViewModel
    {
        public string Label { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public string ButtonText { get; set; }
        public string Url { get; set; }
        public int Diameter { get; set; }
		public string Severity { get; set; }
	    public bool ShowButton { get; set; }
        public int UiGroup { get; set; }
        public int UiPositionInGroup { get; set; }

	    public RadialItemViewModel()
	    {
		    ShowButton = true;
	    }
    }
}