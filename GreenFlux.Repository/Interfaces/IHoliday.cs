using GreenFluxAPI.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenFlux.Infrastructure.Interfaces
{
    public interface IHoliday
    {
        Task<IEnumerable<HolidayDto>> GetCountryWithMostHolidays(int year);
        Task<IEnumerable<HolidayDto>> GetMonthWithMostHolidaysGlobally(int year);
        Task<IEnumerable<HolidayDto>> GetCountryWithMostUniqueHolidays(int year);
    }
}
