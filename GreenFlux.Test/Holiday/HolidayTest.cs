using Xunit;
using GreenFlux.Infrastructure;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GreenFluxAPI.Domain.Dto;

namespace GreenFlux.Test
{
    public class HolidayTest
    {
        [Fact]
        public async Task GetPublicHolidayTestNotFound()
        {
            Holiday holiday = new Holiday();
            var publicHoliday = await holiday.GetPublicHolidays("ABCDE", 2021).Result.Content.ReadAsStringAsync();
            
            Assert.Contains("Not Found", publicHoliday);
        }
    }
}
