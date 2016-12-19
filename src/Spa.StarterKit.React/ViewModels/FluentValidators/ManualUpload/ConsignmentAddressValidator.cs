using FluentValidation;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.ContactInfo;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.Locations.Addresses;
using MPD.Electio.SDK.NetCore.Internal.Validators.v1_1;
using Spa.StarterKit.React.ViewModels.Allocation;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload
{
    public class ConsignmentAddressValidator : AbstractValidator<ConsignmentAddressViewModel>
    {
        public ConsignmentAddressValidator()
        {
            RuleFor(x => x.Line1).NotEmpty().WithMessage("Please enter address line 1");
            RuleFor(x => x.Town).NotEmpty().WithMessage("Please enter a town");
            RuleFor(x => x.CountryIsoCode).NotEmpty().WithMessage("Please choose a country");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid email address").When(x => !string.IsNullOrEmpty(x.Email));

            When(x => !string.IsNullOrEmpty(x.CountryIsoCode) && AddressUtility.RequiresStateCode(CountryValidator.GetCountry(x.CountryIsoCode)), () =>
            {
                RuleFor(x => x.County).NotEmpty().Length(1, 200).WithMessage("Please enter a county/state");
            });
            When(x => !string.IsNullOrEmpty(x.CountryIsoCode) && AddressUtility.RequiresPostcode(CountryValidator.GetCountry(x.CountryIsoCode)), () =>
            {
                RuleFor(x => x.PostCode).NotEmpty().Length(1, 10).WithMessage("Please enter a postcode");
            });

            RuleFor(x => x.LandlineNumber).NotEmpty().Must((telephone) =>
            {
                var phoneNumber = new PhoneNumber(telephone);
                return phoneNumber.IsValid;
            })
            .WithMessage("Please enter a valid landline number")
            .When(x => string.IsNullOrWhiteSpace(x.MobileNumber));

            RuleFor(x => x.MobileNumber).NotEmpty().Must((telephone) =>
            {
                var phoneNumber = new PhoneNumber(telephone);
                return phoneNumber.IsValid;
            })
            .WithMessage("Please enter a valid mobile number")
            .When(x => string.IsNullOrWhiteSpace(x.LandlineNumber));
        }
    }
}