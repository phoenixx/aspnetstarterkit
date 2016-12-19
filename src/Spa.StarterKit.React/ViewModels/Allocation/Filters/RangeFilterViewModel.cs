namespace Spa.StarterKit.React.ViewModels.Allocation.Filters
{
    public class RangeFilterViewModel<T> : FilterBaseViewModel
    {
        public T Start { get; set; }
        public T End { get; set; }
    }
}
