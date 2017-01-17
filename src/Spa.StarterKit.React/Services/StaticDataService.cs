using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using Spa.StarterKit.React.Services.Interfaces;
using Spa.StarterKit.React.ViewModels.AddressLookup;
using Spa.StarterKit.React.ViewModels.Configuration.Rates;

namespace Spa.StarterKit.React.Services
{
    public class StaticDataService : IStaticDataService
    {
        private readonly MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services.IStaticDataService _apiStaticDataService;
        private readonly IMapper _mapper;

        public StaticDataService(
            MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services.IStaticDataService apiStaticDataService,
            IMapper mapper
            )
        {
            _apiStaticDataService = apiStaticDataService;
            _mapper = mapper;
        }

        public async Task<IList<CountryViewModel>> GetCountries()
        {
            var countries = await _apiStaticDataService.GetSupportedCountriesAsync().ConfigureAwait(false);
            return _mapper.Map<List<CountryViewModel>>(countries);
        }

        public async Task<IList<Currency>> GetCurrencies()
        {
            return await _apiStaticDataService.GetSupportedCurrenciesAsync();
        }

        public async Task<IList<TimeZone>> GetTimeszones()
        {
            return (await _apiStaticDataService.GetSupportedTimeZonesAsync().ConfigureAwait(false)).ToList();
        }

        public async Task<IList<string>> GetTitles()
        {
            return await _apiStaticDataService.GetSupportedTitlesAsync().ConfigureAwait(false);
        }

        public async Task<IList<VatRateViewModel>> GetVatRates(string countryIsoCode)
        {
            var result = await _apiStaticDataService.GetVatRatesAsync(countryIsoCode).ConfigureAwait(false);
            return _mapper.Map<List<VatRateViewModel>>(result);
        }
    }
}