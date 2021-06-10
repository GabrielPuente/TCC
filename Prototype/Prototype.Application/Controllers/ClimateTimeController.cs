using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prototype.Domain.Entities;
using Prototype.Service.Interfaces;
using System.Threading.Tasks;

namespace Prototype.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimateTimeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IClimateTimeService _climateTime;

        public ClimateTimeController(IConfiguration configuration, IClimateTimeService climateTime)
        {
            _configuration = configuration;
            _climateTime = climateTime;
        }

        [HttpGet]
        public async Task<ClimateTimeWeather> Get()
        {
            var token = _configuration["ClimateTime:Token"]; // Token gerado no site do climatempo, para uso da API. Armazenado no appsettings do projeto.
            var response = await _climateTime.Get(token);

            return response;
        }
    }
}