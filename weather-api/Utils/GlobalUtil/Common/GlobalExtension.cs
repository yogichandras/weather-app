using System;

namespace GlobalUtil.Common
{
    public static class GlobalExtension
    {
        public static double FahrenheitToCelcius(this double fahrenheitTemp)
        {
            return Math.Round((fahrenheitTemp - 32) * 5 / 9);
        }

        public static string FahrenheitToSkyCondition(this double fahrenheitTemp)
        {
            var temperature = fahrenheitTemp.FahrenheitToCelcius();
            if (temperature < 0.0)
            {
                return "Snow";
            }
            else if (temperature >= 0.0 && temperature < 10.0)
            {
                return "Drizzle";
            }
            else if (temperature >= 10.0 && temperature < 20.0)
            {
                return "Cloudy";
            }
            else if (temperature >= 20.0 && temperature < 30.0)
            {
                return "Sunny";
            }
            else
            {
                return "Clear";
            }
        }
    }
}
