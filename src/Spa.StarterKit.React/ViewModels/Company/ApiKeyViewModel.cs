using System;
using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class ApiKeyViewModel
    {
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}