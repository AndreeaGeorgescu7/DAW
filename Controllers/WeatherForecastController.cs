using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestDAW1.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        private static List <string> Summaries = new List<string>
        {
            "Freezings", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        /*
         Create GET
         Read POST
        Update  PUT/PATCH
        Delete DELETE
         */
        [HttpGet] //read 
        public async Task<IActionResult> GetSummaries()
        {
            return Ok(Summaries);
            /*
             * status code for function Ok
             * 200-ok
             * 204-no content
             * 404-not found
             * 400-bad request
             * 500- intrnal server error
             */

        }

        /*public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }*/
        [HttpGet]
        [Route("summaries/{type}")]

        public async Task<IActionResult> GetSummariesByType(string type)
        {
            return Ok(Summaries[0]);




        }
        [HttpPost]
        
        public async Task<IActionResult> CreateSummary()
        {
            string newSumm = "vara";

            Summaries.Add(newSumm);

            return Ok(Summaries);

        }
        [HttpDelete]
        [Route("{type}")]

        public async Task<IActionResult> DeleteSummary(string type)
        {
            

            Summaries.Remove(type);

            return Ok(Summaries);

        }
        [HttpPatch]
        [Route("{type}")]

        public async Task<IActionResult> UpdateSummary(string type)
        {


            Summaries[0]=type;

            return Ok(Summaries);

        }
    }

}
