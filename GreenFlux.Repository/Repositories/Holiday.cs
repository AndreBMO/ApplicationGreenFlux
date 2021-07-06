using GreenFlux.Infrastructure.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFlux.Infrastructure
{
    public class Holiday : IHoliday
    {
        public async Task<HttpResponseMessage> GetPublicHolidays(string countryCode, int year)
        {
            using (var client = new HttpClient())
            {
                var url = String.Format("https://date.nager.at/api/v3/PublicHolidays/{0}/{1}", year, countryCode);
                return await client.GetAsync(url);
            }
        }
    }
}
