using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFluxAPI.Services.Country
{
    public interface ICountryService
    {
        Task<HttpResponseMessage> GetCountryInfo(string countryCode);
    }
}