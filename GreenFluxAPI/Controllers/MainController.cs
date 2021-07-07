using GreenFluxAPI.Domain.Dto;
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
        //private readonly ICountryService _countryService;
        private readonly IHolidayService _holidayService;

        public MainController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        /// <summary>
        /// Get Public Holidays
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/CountryWithMostHolidaysThisYear/{year}")]
        public async Task<ActionResult<IEnumerable<HolidayDto>>> GetCountryWithMostHolidaysThisYear(
            [FromRoute][Required] int year
            )
        {
            try
            {
                var ret = await _holidayService.GetCountryWithMostHolidays(year);
                
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
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/MonthWithMostHolidaysGlobally/{year}")]
        public async Task<ActionResult<IEnumerable<HolidayDto>>> GetMonthWithMostHolidaysGlobally(
            [FromRoute][Required] int year
            )
        {
            try
            {
                var ret = await _holidayService.GetMonthWithMostHolidaysGlobally(year);

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
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/CountryWithMostUniqueHolidays/{year}")]
        public async Task<ActionResult<IEnumerable<HolidayDto>>> GetCountryWithMostUniqueHolidays(
            [FromRoute][Required] int year
            )
        {
            try
            {
                var ret = await _holidayService.GetCountryWithMostUniqueHolidays(year);

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