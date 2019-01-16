using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using unitronicsWebApi.Model;
using unitronicsWebApi.parking;

namespace unitronicsWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ParkingController : Controller
    {

        private readonly IParkingMAnager _parkingManager;
        private IMemoryCache _cache;



        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public ParkingController(IParkingMAnager parkingMAnager, IMemoryCache memoryCache)
        {
            _parkingManager = parkingMAnager;
            _cache = memoryCache;


        }

        protected Task<IActionResult> NewTask(Func<IActionResult> callback)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    return callback();
                }
                catch (Exception ex)
                {
                   // Logger.LogError(ex.ToString());
                    throw;
                }
            });
        }

        [HttpPost("checkin")]
        public async Task<IActionResult> checkin([FromBody]Parking parking)
        {
            return await NewTask(() =>
            {
                var result = _parkingManager.chekIn (parking);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Role not found");
            });
        }


        [HttpPost("checkinBulkAsync")]
        public async Task<IActionResult> checkin([FromBody]List<Parking> parking)
        {
            //run parralel  checkin process for group of parking...
            return await NewTask(() =>
            {
            (parking).ForEach(
                 i => {
                  Console.WriteLine(i.ToString());
                  var result = _parkingManager.chekIn(i);
                 }
               
                        //if (result != null)
                        //    return Ok(result);
                        //else
                        //    return NotFound("Role not found");
                    );
                return Ok("");


            });
        }
        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            
           
           



           
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }





        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
