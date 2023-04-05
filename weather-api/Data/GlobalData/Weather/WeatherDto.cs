using System;

namespace GlobalData.Weather
{
    public class WeatherDto
    {
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public WindDto Wind { get; set; }
        public double Visibility { get; set; }
        public string SkyConditions { get; set; }
        public double CelsiusTemperature { get; set; }
        public double FahrenheitTemperature { get; set; }
        public double DewPoint { get; set; }
        public double RelativeHumidity { get; set; }
        public double Pressure { get; set; }
    }
}
