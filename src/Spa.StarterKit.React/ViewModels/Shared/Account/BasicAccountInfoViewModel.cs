using System.ComponentModel;

namespace Spa.StarterKit.React.ViewModels.Shared.Account
{
    public class BasicAccountInfoViewModel
    {
        public string Title { get; set; }

        [DisplayName("First Name")]
        public string FirstName {get;set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set;}

        [DisplayName("Landline Number")]
        public string LandlineNumber { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get;set;}
    }
}