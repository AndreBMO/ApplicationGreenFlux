using GreenFluxAPI.Domain.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFluxAPI.Services.Holiday
{
    public interface IHolidayService
    {
        Task<IEnumerable<HolidayDto>> GetCountryWithMostHolidays(int year);
        Task<IEnumerable<HolidayDto>> GetMonthWithMostHolidaysGlobally(int year);
        Task<IEnumerable<HolidayDto>> GetCountryWithMostUniqueHolidays(int year);
    }
}
