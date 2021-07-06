using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFlux.Infrastructure.Interfaces
{
    public interface IHoliday
    {
        Task<HttpResponseMessage> GetPublicHolidays(string countryCode, int year);
    }
}
