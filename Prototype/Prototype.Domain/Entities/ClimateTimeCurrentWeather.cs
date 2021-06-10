using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Prototype.Domain.Entities
{

    /// <summary>
    ///  Classe para o desserializar o json de retorna da api interna
    ///  e manipular os dados com mais facilidade pelo C#
    /// </summary>
    public class ClimateTimeWeather
    {
        public ClimateTimeCurrentWeather WeatherCurrent { get; set; }
        public List<ClimateTimeWeatherForecast> WeatherForecast { get; set; }
    }

    public class ClimateTimeWeatherForecastJson
    {
        [JsonProperty("Data")]
        public List<ClimateTimeWeatherForecast> WeatherForecast { get; set; }
    }
    
    public class ClimateTimeCurrentWeatherJson
    {
        [JsonProperty("Data")]
        public ClimateTimeCurrentWeather WeatherCurrent { get; set; }
    }

    public class ClimateTimeCurrentWeather
    {
        public decimal Temperature { get; set; }
        [JsonProperty("Wind_Direction")]
        public string WindDirection { get; set; }
        [JsonProperty("Wind_Velocity")]
        public decimal WindVelocity { get; set; }
        public decimal Humidity { get; set; }
        public string Condition { get; set; }
        public decimal Pressure { get; set; }
        public decimal? Sensation { get; set; }
        public DateTime Date { get; set; }
        public string Icon { get; set; }
    }

    public class ClimateTimeWeatherForecast
    {
        public DateTime Date { get; set; }
        public Humidity Humidity { get; set; }
        public Rain Rain { get; set; }
        public Wind Wind { get; set; }
        [JsonProperty("thermal_sensation")]
        public ThermalSensation ThermalSensation { get; set; }
        public Temperature Temperature { get; set; }
        [JsonProperty("text_icon")]
        public TextIcon TextIcon { get; set; }
    }

    public class Humidity
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class Rain
    {
        public int Probability { get; set; }
    }

    public class Wind
    {
        [JsonProperty("velocity_min")]
        public int Min { get; set; }
        [JsonProperty("velocity_max")]
        public int Max { get; set; }
        public string Direction { get; set; }
    }

    public class ThermalSensation
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class Temperature
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class TextIcon
    {
        public Text Text { get; set; }
        public Icon Icon { get; set; }
    }

    public class Icon
    {
        [JsonProperty("afternoon")]
        public string IconDesing { get; set; }
    }

    public class Text
    {
        [JsonProperty("pt")]
        public string Description { get; set; }
    }
}