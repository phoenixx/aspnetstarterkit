namespace Spa.StarterKit.React.ViewModels.Shared.Address
{
    public class UkPostcodeViewModel
    {
        private string _area;
        private string _district;
        private string _sector;
        private string _unit;

        public int Id { get; set; }

        public string Area
        {
            get { return _area ?? string.Empty; }
            set { _area = value; }
        }

        public string District
        {
            get { return _district ?? string.Empty; }
            set { _district = value; }
        }

        public string Sector
        {
            get { return _sector ?? string.Empty; }
            set { _sector = value; }
        }

        public string Unit
        {
            get { return _unit ?? string.Empty; }
            set { _unit = value; }
        }
    }
}