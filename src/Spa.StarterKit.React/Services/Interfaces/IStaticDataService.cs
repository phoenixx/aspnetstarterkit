using System.Collections.Generic;
using System.Threading.Tasks;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using Spa.StarterKit.React.ViewModels.AddressLookup;
using Spa.StarterKit.React.ViewModels.Configuration.Rates;

namespace Spa.StarterKit.React.Services.Interfaces
{
    public interface IStaticDataService
    {
        Task<IList<CountryViewModel>> GetCountries();
        Task<IList<Currency>> GetCurrencies();
        Task<IList<TimeZone>> GetTimeszones();
        Task<IList<string>> GetTitles();
        Task<IList<VatRateViewModel>> GetVatRates(string countryIsoCode);
    }
}