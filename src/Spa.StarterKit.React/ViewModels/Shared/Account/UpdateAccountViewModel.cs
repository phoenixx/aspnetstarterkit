using System;
using System.Collections.Generic;
using FluentValidation.Attributes;
using Spa.StarterKit.React.ViewModels.FluentValidators.Account;
using Spa.StarterKit.React.ViewModels.Roles;

namespace Spa.StarterKit.React.ViewModels.Shared.Account
{
    [Validator(typeof(UpdateAccountValidator))]
    public class UpdateAccountViewModel
    {
        public Guid AccountReference { get; set; }

        public Guid CompanyReference { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CurrentEmailAddress { get; set; }

		public string NewEmailAddress { get; set; }

        public string LandlineNumber { get; set; }

        public string MobileNumber { get; set; }

        public IList<RoleViewModel> Roles { get; set; }

        public string CarrierServiceSetRef { get; set; }

        public int TimeZoneId { get; set; }

        public bool IsDisabled { get; set; }

        public string LanguageCode { get { return "en"; } }

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }

        public bool PasswordChanged { get; set; }

        public IList<string> ShippingLocationReferences { get; set; }
    }
}