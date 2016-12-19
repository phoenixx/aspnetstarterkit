using FluentValidation;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.Locations.Addresses;
using MPD.Electio.SDK.NetCore.Internal.Validators.v1_1;
using Spa.StarterKit.React.ViewModels.Shared.Address;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Shared
{
    public class AddressViewModelValidator<T> : AbstractValidator<T> where T : AddressViewModel
    {
        public AddressViewModelValidator()
        {
            RuleFor(x => x.Line1).NotEmpty().Length(1, 200).WithMessage("Please enter address line 1");
            RuleFor(x => x.Line3).Length(1, 200);
            RuleFor(x => x.Town).NotEmpty().Length(1, 200).WithMessage("Please enter a town");
            RuleFor(x => x.CountryIsoCode).NotEmpty().WithMessage("Please choose a country");
            When(x => !string.IsNullOrEmpty(x.CountryIsoCode) && AddressUtility.RequiresStateCode(CountryValidator.GetCountry(x.CountryIsoCode)), () =>
            {
                RuleFor(x => x.County).NotEmpty().Length(1, 200).WithMessage("Please enter a county/state");
            });
            When(x => !string.IsNullOrEmpty(x.CountryIsoCode) && AddressUtility.RequiresPostcode(CountryValidator.GetCountry(x.CountryIsoCode)), () =>
            {
                RuleFor(x => x.PostCode).NotEmpty().Length(1, 10).WithMessage("Please enter a postcode");
            });
        }
    }
}