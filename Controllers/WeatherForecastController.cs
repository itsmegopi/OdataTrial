using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataRD.Controllers
{
    public class WeatherForecastController : ODataController
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<WeatherForecast> Get()
        {
            return GetAllList();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<WeatherForecast> Get(int key)
        {
            IQueryable<WeatherForecast> res = GetAllList().Where(g => g.WeatherForecastId == key).AsQueryable();
            return SingleResult.Create(res);
        }

        [HttpGet, Route("GetRequest2")]
        [EnableQuery]
        public IQueryable<WeatherForecast> Get2(int forecastId, int temparature)
        {
            IQueryable<WeatherForecast> res = GetAllList()
                .Where(g => g.WeatherForecastId == forecastId && g.TemperatureC == temparature)
                .AsQueryable();
            return res;
        }

        [HttpGet, Route("api/v1/WeatherForecast/GetRequest3")]
        [EnableQuery]
        public IQueryable<WeatherForecast> Get3(int forecastId, int temparature)
        {
            IQueryable<WeatherForecast> res = GetAllList()
                .Where(g => g.WeatherForecastId == forecastId && g.TemperatureC == temparature)
                .AsQueryable();
            return res;
        }

        [HttpGet, Route("api/v1/GetRequest4")]
        [EnableQuery]
        public IQueryable<WeatherForecast> Get4(int forecastId, int temparature)
        {
            IQueryable<WeatherForecast> res = GetAllList()
                .Where(g => g.WeatherForecastId == forecastId && g.TemperatureC == temparature)
                .AsQueryable();
            return res;
        }

        [HttpGet, Route("api/v1/WeatherForecast/GetRequest5/{forecastId}/{temparature}")]
        [EnableQuery]
        public IQueryable<WeatherForecast> Get5(int forecastId, int temparature)
        {
            IQueryable<WeatherForecast> res = GetAllList()
                .Where(g => g.WeatherForecastId == forecastId && g.TemperatureC == temparature)
                .AsQueryable();
            return res;
        }

        private static IEnumerable<WeatherForecast> GetAllList()
        {
            var result = new List<WeatherForecast>
            {
                new WeatherForecast() { WeatherForecastId = 1, Date = DateTime.Parse("2022-08-20T06:50:46.873Z"), Summary = "A1", TemperatureC = 10, TemperatureF = 120 },
                new WeatherForecast() { WeatherForecastId = 2, Date = DateTime.Parse("2022-08-20T06:50:46.873Z"), Summary = "A2", TemperatureC = 11, TemperatureF = 1200 },
                new WeatherForecast() { WeatherForecastId = 3, Date = DateTime.Parse("2022-09-20T06:50:46.873Z"), Summary = "A3", TemperatureC = 12, TemperatureF = 1201 },
                new WeatherForecast() { WeatherForecastId = 4, Date = DateTime.Parse("2022-09-20T06:50:46.873Z"), Summary = "A4", TemperatureC = 13, TemperatureF = 1202 },
                new WeatherForecast() { WeatherForecastId = 5, Date = DateTime.Parse("2022-09-20T06:50:46.873Z"), Summary = "A5", TemperatureC = 14, TemperatureF = 1204 },
                new WeatherForecast() { WeatherForecastId = 6, Date = DateTime.Parse("2022-07-20T06:50:46.873Z"), Summary = "A6", TemperatureC = 15, TemperatureF = 1206 },
                new WeatherForecast() { WeatherForecastId = 7, Date = DateTime.Parse("2022-06-20T06:50:46.873Z"), Summary = "A7", TemperatureC = 16, TemperatureF = 1207 },
                new WeatherForecast() { WeatherForecastId = 8, Date = DateTime.Parse("2022-05-20T06:50:46.873Z"), Summary = "A8", TemperatureC = 17, TemperatureF = 1208 },
                new WeatherForecast() { WeatherForecastId = 9, Date = DateTime.Parse("2022-04-20T06:50:46.873Z"), Summary = "A9", TemperatureC = 18, TemperatureF = 1209 },
                new WeatherForecast() { WeatherForecastId = 10, Date = DateTime.Parse("2022-03-20T06:50:46.873Z"), Summary = "A11", TemperatureC = 19, TemperatureF = 1270 }
            };
            return result;
        }
    }
}