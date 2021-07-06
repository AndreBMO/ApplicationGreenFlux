using GreenFlux.Infrastructure.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFluxAPI.Services.Country
{
    public class CountryService : ICountryService
    {
        private readonly ICountry _country;

        public CountryService(ICountry country)
        {
            _country = country;
        }

        public async Task<HttpResponseMessage> GetCountryInfo(string countryCode)
        {
            return await _country.GetCountryInfo(countryCode);
        }
    }
}
