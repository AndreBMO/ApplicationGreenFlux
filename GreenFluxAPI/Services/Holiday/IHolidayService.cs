using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFluxAPI.Services.Holiday
{
    public interface IHolidayService
    {
        Task<HttpResponseMessage> GetPublicHolidays(string countryCode, int year);
    }
}
