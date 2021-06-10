namespace Prototype.Service.Constant
{
    /// <summary>
    /// Classe criada para padronizar o local das urls das api externas.
    /// Classe static pois os valores dela nao devem mudar.
    /// </summary>
    public static class ClimateTimeConstant
    {
        public static string UrlCurrentWeather = "http://apiadvisor.climatempo.com.br/api/v1/weather/locale/3496/current?token=";
        public static string UrlForecast15Days = "http://apiadvisor.climatempo.com.br/api/v1/forecast/locale/3496/days/15?token=";
    }
}
