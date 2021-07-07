using GreenFlux.Domain.Model;
using GreenFlux.Infrastructure.Interfaces;
using GreenFluxAPI.Domain.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GreenFlux.Infrastructure
{
    public class Holiday : BaseRepository, IHoliday
    {
        public async Task<IEnumerable<HolidayDto>> GetCountryWithMostHolidays(int year)
        {
            using (var client = new HttpClient())
            {
                var count = 0;
                var currCount = 0;
                var countryCode = "";                

                var holiday = await GetHolidays(year);

                foreach (var code in countryCodes.Keys)
                {                    
                    currCount = holiday.Where(x => x.CountryCode == code).Count();

                    if (currCount > count)
                    {
                        count = currCount;
                        countryCode = code;
                    }
                }

                return holiday.Where(x => x.CountryCode == countryCode);                
            }
        }

        public async Task<IEnumerable<HolidayDto>> GetMonthWithMostHolidaysGlobally(int year)
        {
            var firstDayOfMonth = new DateTime();
            var lastDayOfMonth = new DateTime();
            var count = 0;
            var currCount = 0;
            var month = 0;

            var AllHolidays = await GetHolidays(year);

            for (var i = 1; i <= 12; i++)
            {
                firstDayOfMonth = new DateTime(DateTime.Now.Year, i, 1);
                lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);
                currCount = AllHolidays.Where(x => x.Date >= firstDayOfMonth && x.Date <= lastDayOfMonth && x.Global == true).Count();
                
                if (currCount > count)
                {
                    count = currCount;
                    month = i;
                }
            }

            firstDayOfMonth = new DateTime(DateTime.Now.Year, month, 1);
            lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);

            return AllHolidays.Where(x => x.Date >= firstDayOfMonth && x.Date <= lastDayOfMonth).OrderBy(x => x.Date);
        }

        public async Task<IEnumerable<HolidayDto>> GetCountryWithMostUniqueHolidays(int year)
        {
            IEnumerable<HolidayDto> countryHolidays = new HolidayDto[] { };
            var count = 0;
            var currCount = 0;
            var firstDayOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            var lastDayOfYear = firstDayOfYear.AddYears(1).AddTicks(-1);
            var countryCode = "";

            var AllHolidays = await GetHolidays(year);

            foreach (var code in countryCodes.Keys)
            {
                countryHolidays = AllHolidays.Where(x => x.CountryCode == code);

                var compareList = AllHolidays.Where(x => !countryHolidays.Any(l => x.CountryCode == l.CountryCode)).ToList();

                var uniqueHolidays = countryHolidays.Where(x => !compareList.Any(l => x.Date == l.Date));

                currCount = uniqueHolidays.Count();

                if (currCount > count)
                {
                    count = currCount;
                    countryCode = code;
                }
            }

            return AllHolidays.Where(x => x.CountryCode == countryCode);
        }

        public async Task<IEnumerable<HolidayDto>> GetHolidaysNagerDate(int year, IEnumerable<KeyValuePair<string, CountryCode>> countryCodes)
        {
            var AllHolidays = new List<HolidayDto>();

            using (var client = new HttpClient())
            {
                var urlAPI = "https://date.nager.at/api/v3/PublicHolidays/{0}/{1}";
                foreach (var code in countryCodes)
                {
                    var url = String.Format(urlAPI, year, code.Key);
                    var apiResponse = await client.GetAsync(url).Result.Content.ReadAsStringAsync();
                    var holiday = JsonConvert.DeserializeObject<IEnumerable<HolidayDto>>(apiResponse);
                    AllHolidays.AddRange(holiday);
                }

                return AllHolidays;
            }
        }

        public async Task<IEnumerable<HolidayDto>> GetHolidays(int year)
        {
            var batchSize = 50;
            int numberOfBatches = (int)Math.Ceiling((double)countryCodes.Keys.Count() / batchSize);
            var holidays = new List<HolidayDto>();
            var tasks = new List<Task<IEnumerable<HolidayDto>>>();

            for (int i = 0; i < numberOfBatches; i++)
            {
                var currentCodes = countryCodes.Skip(i * batchSize).Take(batchSize);
                tasks.Add(GetHolidaysNagerDate(year, currentCodes));                
            }

            return (await Task.WhenAll(tasks)).SelectMany(u => u);            
        }
    }
}
