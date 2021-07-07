using GreenFluxAPI.Domain.Dto;
using GreenFluxAPI.Services.Country;
using GreenFluxAPI.Services.Holiday;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GreenFluxAPI.Controllers
{
    /// <summary>
    /// Main
    /// </summary>
    public class MainController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IHolidayService _holidayService;

        public MainController(ICountryService countryService, IHolidayService holidayService)
        {
            _countryService = countryService;
            _holidayService = holidayService;
        }

        /// <summary>
        /// Get Public Holidays
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{countryCode}/{year}")]
        public async Task<ActionResult<IEnumerable<HolidayDto>>> GetPublicHoliday(
            [FromRoute][Required] string countryCode,
            [FromRoute][Required] int year
            )
        {
            try
            {
                var response = _holidayService.GetPublicHolidays(countryCode, year);
                var apiResponse = await response.Result.Content.ReadAsStringAsync();
                var ret = JsonConvert.DeserializeObject<IEnumerable<HolidayDto>>(apiResponse);

                if (ret != null)
                {
                    return this.StatusCode(StatusCodes.Status200OK, ret);
                }

                return this.StatusCode(StatusCodes.Status404NotFound);                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        /// <summary>
        /// Get Country Information
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{countryCode}")]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetInfoByCountry(
            [FromRoute][Required] string countryCode
            )
        {
            try
            {
                var response = _countryService.GetCountryInfo(countryCode);
                var apiResponse = await response.Result.Content.ReadAsStringAsync();
                var ret = JsonConvert.DeserializeObject<CountryDto>(apiResponse);

                if (ret != null)
                {
                    return this.StatusCode(StatusCodes.Status200OK, ret);
                }

                return this.StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }    
}