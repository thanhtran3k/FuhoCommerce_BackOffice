using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FuhoCommerce.HttpUtility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FuhoCommerce.ApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly RestInvoker _restInvoker;
        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(ILogger<WeatherForecastController> logger, RestInvoker restInvoker)
        {
            _logger = logger;
            _restInvoker = restInvoker;
        }

        [Authorize(Policy = "Supplier")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var rng = new List<string>() { "Tested" };
            return rng;
        }

        [HttpGet("testSsl")]
        public async Task<IEnumerable<WeatherForecast>> GetWithSSL()
        {
            //Localhost can ignore certificate check if enable ignoreSelfSignedCertificateCheck in setting
            var url = "https://localhost:44369/weatherforecast";
            var header = new Dictionary<string, string>();
            var result = await _restInvoker.GetAsync<IEnumerable<WeatherForecast>>(url, header);
            return result;
        }
    }
}
