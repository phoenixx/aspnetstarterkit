using System;
using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.Roles;

namespace Spa.StarterKit.React.ViewModels.User
{
    [Serializable]
    public class AccountViewModel
    {
        public Guid AccountReference { get; set; }
        public Guid CompanyReference { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string LanguageCode { get; set; }
        public string TimeZoneInfoId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDisabled
        {
            get { return !IsEnabled; }
            set { IsEnabled = !value; }
        }
        public string LandLineNumber { get; set; }
        public string MobileNumber { get; set; }
        public bool IsMainCustomerContact { get; set; }
        public IList<RoleViewModel> Roles { get; set; }
    }
}