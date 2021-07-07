using Xunit;
using GreenFlux.Infrastructure;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GreenFluxAPI.Domain.Dto;
using System.Linq;

namespace GreenFlux.Test
{
    public class HolidayTest
    {
        [Fact]
        public async Task GetPublicHolidayTest()
        {
            Holiday holiday = new Holiday();
            var publicHoliday = await holiday.GetCountryWithMostHolidays(2021);
            var list = publicHoliday.ToList();
            
            Assert.Equal("VE", list[0].CountryCode);
        }
    }
}
