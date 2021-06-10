using System;
using System.Collections.Generic;

namespace Prototype.DomainMVC.ViewModel
{

    /// <summary>
    /// Classe para o desserializar o json de retorna da api interna
    /// </summary>

    public class ClimateTimeWeather
    {
        public ClimateTimeCurrentWeather WeatherCurrent { get; set; }
        public List<ClimateTimeWeatherForecast> WeatherForecast { get; set; }
    }

    public class ClimateTimeWeatherForecastJson
    {
        public List<ClimateTimeWeatherForecast> WeatherForecast { get; set; }
    }

    public class ClimateTimeCurrentWeatherJson
    {
        public ClimateTimeCurrentWeather WeatherCurrent { get; set; }
    }

    public class ClimateTimeCurrentWeather
    {
        public decimal Temperature { get; set; }
        public string WindDirection { get; set; }
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
        public ThermalSensation ThermalSensation { get; set; }
        public Temperature Temperature { get; set; }
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
        public int Min { get; set; }
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
        public string IconDesing { get; set; }
    }

    public class Text
    {
        public string Description { get; set; }
    }
}
