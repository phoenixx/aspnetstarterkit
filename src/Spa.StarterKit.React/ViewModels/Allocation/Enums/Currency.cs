using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.ViewModels.Allocation.Enums
{
    /// <summary>
    /// For initial phase we will just support GBP but we will need to support other currencies.  Ideally, strip this out and retrieve from a service
    /// </summary>
    public enum Currency
    {
        [Display(Name = "GBP (£)")]
        GBP = 0
    }
}
