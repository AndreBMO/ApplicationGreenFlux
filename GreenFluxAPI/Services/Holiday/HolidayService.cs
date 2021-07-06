using GreenFlux.Infrastructure;
using GreenFlux.Infrastructure.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFluxAPI.Services.Holiday
{
    public class HolidayService : IHolidayService
    {
        private readonly IHoliday _holiday;

        public HolidayService(IHoliday holiday)
        {
            _holiday = holiday;
        }
        public async Task<HttpResponseMessage> GetPublicHolidays(string countryCode, int year)
        {
            return await _holiday.GetPublicHolidays(countryCode, year);
        }
    }
}
