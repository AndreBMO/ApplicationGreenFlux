using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFlux.Infrastructure.Interfaces
{
    public interface ICountry
    {
        Task<HttpResponseMessage> GetCountryInfo(string countryCode);
    }
}
