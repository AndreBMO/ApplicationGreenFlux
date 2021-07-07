using Xunit;
using GreenFlux.Infrastructure;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GreenFluxAPI.Domain.Dto;

namespace GreenFlux.Test
{
    public class CountryTest
    {
        [Fact]
        public async Task GetCountryInfoTestSuccessfull()
        {
            Country country = new Country();
            var countryInfo = await country.GetCountryInfo("BR").Result.Content.ReadAsStringAsync();
            var countryInfoDeserialized = JsonConvert.DeserializeObject<CountryDto>(countryInfo);

            Assert.Equal("Brazil", countryInfoDeserialized.name);
        }
    }
}
