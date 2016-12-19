using System.Collections.Generic;
using System.ComponentModel;
using Spa.StarterKit.React.ViewModels.Roles;

namespace Spa.StarterKit.React.ViewModels.Shared.Account
{
    public class AccountInfoViewModel
    {
        public string AccountReference { get; set; }

        public string CompanyReference { get; set; }

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

        [DisplayName("Role")]
        public IList<RoleViewModel> Roles { get; set; }

        [DisplayName("Carrier restrictions")]
        public string CarrierServiceSetName { get; set; }

        [DisplayName("Main contact?")]
        public bool IsMainCustomerContact { get; set; }

        [DisplayName("Timezone")]
        public string TimeZoneId { get; set; }

    }
}