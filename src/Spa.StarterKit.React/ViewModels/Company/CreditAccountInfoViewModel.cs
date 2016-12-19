using System;
using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class CreditAccountInfoViewModel
    {
        public CreditAccountInfoViewModel()
        {
        }

        [Display(Name="Credit Limit")]
        [Required(ErrorMessage = "Please enter a valid credit limit greater than £0.00")]
        [Range(0.01,double.MaxValue,ErrorMessage = "Please enter a valid credit limit greater than £0.00")]
        public decimal CreditLimit { get; set; }
        [Display(Name = "Payment Terms")]
        [Required(ErrorMessage = "Please choose valid payment terms")]
        public int PaymentTerms { get; set; }
        public Guid CustomerReference { get; set; }
        public bool CanEdit { get; set; }
    }
}