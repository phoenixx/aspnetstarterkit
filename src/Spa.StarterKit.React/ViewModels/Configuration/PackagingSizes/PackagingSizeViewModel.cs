using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.ViewModels.Configuration.PackagingSizes
{
    public class PackagingSizeViewModel
    {
        public string MPDReference { get; set; }

        public string Reference { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Length { get; set; }

        [Required]
        public decimal Width { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal Weight { get; set; }

        public bool IsDefault { get; set; }
    }
}
