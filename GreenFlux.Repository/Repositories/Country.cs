using GreenFlux.Infrastructure.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFlux.Infrastructure
{
    public class Country : ICountry
    {
        public async Task<HttpResponseMessage> GetCountryInfo(string countryCode)
        {
            using (var client = new HttpClient())
            {
                var url = String.Format("https://restcountries.eu/rest/v2/alpha/{0}", countryCode);
                return await client.GetAsync(url);
            }
        }
    }
}
