using Newtonsoft.Json;
using Prototype.Domain.Entities;
using Prototype.Service.Constant;
using Prototype.Service.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prototype.Service.Services
{
    public class ClimateTimeService : IClimateTimeService
    {
        private readonly HttpClient _client;

        public ClimateTimeService()
        {
            _client = new HttpClient();
        }

        public async Task<ClimateTimeWeather> Get(string token)
        {
            var url = $"{ClimateTimeConstant.UrlCurrentWeather}{token}"; //Define uma rota a ser feita a requisição
            var responseModel = new ClimateTimeWeather(); //Cria a classe a ser usada para retorno do metodo

            var response = await _client.GetAsync(url); //Faz um requisicao GET para a URL definida acima
            var currentWather = JsonConvert.DeserializeObject<ClimateTimeCurrentWeatherJson>(await response.Content.ReadAsStringAsync()); //Desserializa o json de retorno para uma classe C# do tipo ClimateTimeCurrentWeatherJson

            url = $"{ClimateTimeConstant.UrlForecast15Days}{token}"; //Define uma rota a ser feita a requisição

            response = await _client.GetAsync(url); //Faz um requisicao GET para a URL definida acima
            var ForecastWeather = JsonConvert.DeserializeObject<ClimateTimeWeatherForecastJson>(await response.Content.ReadAsStringAsync());//Desserializa o json de retorno para uma classe C# do tipo ClimateTimeWeatherForecastJson

            responseModel.WeatherCurrent = currentWather.WeatherCurrent; //Guarda as informacoes na classe de retorno
            responseModel.WeatherForecast = ForecastWeather.WeatherForecast; //Guarda as informacoes na classe de retorno
            return responseModel; //Retorna a classe com os dados obtidos
        }
    }
}
