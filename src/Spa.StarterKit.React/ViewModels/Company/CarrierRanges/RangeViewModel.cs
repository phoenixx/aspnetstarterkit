namespace Spa.StarterKit.React.ViewModels.Company.CarrierRanges
{
    public class RangeViewModel
    {
        public long Id { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
        public int Order { get; set; }
        public bool IsCurrent { get; set; }
        public int Step { get; set; }
        public bool RecordIsNotInDatabase { get; set; }
    }
}