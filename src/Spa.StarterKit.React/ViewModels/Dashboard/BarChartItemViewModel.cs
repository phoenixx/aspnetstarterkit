namespace Spa.StarterKit.React.ViewModels.Dashboard
{
    public class BarChartItemViewModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Url { get; set; }

	    public BarChartItemViewModel()
	    {
		    
	    }

	    public BarChartItemViewModel(string name, int value, string url)
	    {
		    Name = name;
		    Value = value;
		    Url = url;
	    }
    }
}