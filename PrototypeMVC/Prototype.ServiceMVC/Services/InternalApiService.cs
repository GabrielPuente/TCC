using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Prototype.DomainMVC.ViewModel;
using Prototype.ServiceMVC.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prototype.ServiceMVC.Services
{
    public class InternalApiService : IInternalApiService
    {
        private readonly IConfiguration _configuration;
        private HttpClient _client;

        public InternalApiService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new();
        }

        public async Task<ClimateTimeWeather> Index()
        {
            var url = _configuration["Urls:InternalAPIClimateTime"]; //Define a url do endpoint, esta na configuracao do projeto, no appsettings
            var response = await _client.GetAsync(url); //Faz uma requisicao GET para a url acima

            var forecastWeather = JsonConvert.DeserializeObject<ClimateTimeWeather>(await response.Content.ReadAsStringAsync()); //Desserializa o json de retorno para uma classe C# do tipo ClimateTimeWeather

            forecastWeather.WeatherCurrent.WindDirection = DirectionWind(forecastWeather.WeatherCurrent.WindDirection); //Passa o a sigla do vento do tempo atual retornado para o metodo "DirectionWind" para retornar o nome por extenso
            forecastWeather.WeatherForecast.ForEach(x => x.Wind.Direction = DirectionWind(x.Wind.Direction)); //Faz o mesmo que acima, mas para todos os itens da previsao do tempo de N dias

            return forecastWeather; // Retorna a view com os dados
        }

        public async Task<ClimateTimeWeather> Tips()
        {
            var url = _configuration["Urls:InternalAPIClimateTime"]; //Define a url do endpoint, esta na configuracao do projeto, no appsettings
            var response = await _client.GetAsync(url); //Faz uma requisicao GET para a url acima

            var forecastWeather = JsonConvert.DeserializeObject<ClimateTimeWeather>(await response.Content.ReadAsStringAsync()); //Desserializa o json de retorno para uma classe C# do tipo ClimateTimeWeather

            forecastWeather.WeatherCurrent.WindDirection = DirectionWind(forecastWeather.WeatherCurrent.WindDirection); //Passa o a sigla do vento do tempo atual retornado para o metodo "DirectionWind" para retornar o nome por extenso
            forecastWeather.WeatherForecast.ForEach(x => x.Wind.Direction = DirectionWind(x.Wind.Direction)); //Faz o mesmo que acima, mas para todos os itens da previsao do tempo de N dias

            return forecastWeather; // Retorna a view com os dados
        }

        public async Task<ClimateTimeWeather> Gallery()
        {
            var url = _configuration["Urls:InternalAPIClimateTime"]; //Define a url do endpoint, esta na configuracao do projeto, no appsettings
            var response = await _client.GetAsync(url); //Faz uma requisicao GET para a url acima

            var forecastWeather = JsonConvert.DeserializeObject<ClimateTimeWeather>(await response.Content.ReadAsStringAsync()); //Desserializa o json de retorno para uma classe C# do tipo ClimateTimeWeather

            forecastWeather.WeatherCurrent.WindDirection = DirectionWind(forecastWeather.WeatherCurrent.WindDirection); //Passa o a sigla do vento do tempo atual retornado para o metodo "DirectionWind" para retornar o nome por extenso
            forecastWeather.WeatherForecast.ForEach(x => x.Wind.Direction = DirectionWind(x.Wind.Direction)); //Faz o mesmo que acima, mas para todos os itens da previsao do tempo de N dias

            return forecastWeather; // Retorna a view com os dados
        }

        /// <summary>
        /// Metodo DEPARA, recebe a sigla e devolve o extenso da direcao do vento
        /// </summary>
        /// <param name="direction">Sigla da direcao do vento, recebido pela api</param>
        /// <returns>Retorna a direção do vento escrito por extenso</returns>
        private static string DirectionWind(string direction)
        {
            return direction switch
            {
                "N" => "Norte",
                "S" => "Sul",
                "E" => "Leste",
                "W" => "Oeste",
                "NE" => "Nordeste",
                "SE" => "Sudeste",
                "NW" => "Noroeste",
                "SW" => "Sudoeste",
                "NNE" => "Nordeste",
                "NNW" => "Noroeste",
                "WNW" => "Noroeste",
                "SSE" => "Sudeste",
                "SSW" => "Sudoeste",
                "ENE" => "Nordeste",
                "ESE" => "Sudeste",
                "WSE" => "Sudeste",
                "WSW" => "Sudoeste",
                _ => throw new System.NotImplementedException(),
            };
        }
    }
}
