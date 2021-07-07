using GreenFlux.Infrastructure;
using GreenFlux.Infrastructure.Interfaces;
using GreenFluxAPI.Domain.Dto;
using System.Collections.Generic;
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
        public async Task<IEnumerable<HolidayDto>> GetCountryWithMostHolidays(int year)
        {
            return await _holiday.GetCountryWithMostHolidays(year);
        }

        public async Task<IEnumerable<HolidayDto>> GetMonthWithMostHolidaysGlobally(int year)
        {
            return await _holiday.GetMonthWithMostHolidaysGlobally(year);
        }

        public async Task<IEnumerable<HolidayDto>> GetCountryWithMostUniqueHolidays(int year)
        {
            return await _holiday.GetCountryWithMostUniqueHolidays(year);
        }
    }
}
