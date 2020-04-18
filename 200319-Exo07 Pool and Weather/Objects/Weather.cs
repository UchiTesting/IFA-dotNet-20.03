using System;
using System.Collections.Generic;
using System.Text;
using _200319_Exo07_Pool_and_Weather.Enums;

namespace _200319_Exo07_Pool_and_Weather.Objects
{
    public class Weather : AbstractFlowing
    {
        public static Weather GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Weather(WeatherEnum.SUNNY);
            }

            return Instance;
        }

        private static Weather Instance;
        public event EventHandler WeatherChangeEvent;
        public WeatherEnum TheWeather { get; set; }
        private Weather(WeatherEnum weather, double flux = 1) : base(flux) { TheWeather = weather; }

        public void UpdateWeather(WeatherEnum NewWeather)
        {
            if (TheWeather != NewWeather)
            {
                TheWeather = NewWeather;
                UpdateFlow();
                WeatherChangeEvent?.Invoke(this, EventArgs.Empty);
            }
        }
        private void UpdateFlow()
        {
            switch (TheWeather)
            {
                case WeatherEnum.DEWY:
                    State = VolumeChangerStateEnum.ACTIVE;
                    Flow = 0.05;
                    break;
                case WeatherEnum.RAINY:
                    State = VolumeChangerStateEnum.ACTIVE;
                    Flow = 0.5;
                    break;
                case WeatherEnum.STORMY:
                    State = VolumeChangerStateEnum.ACTIVE;
                    Flow = 1;
                    break;
                case WeatherEnum.SUNNY:
                    State = VolumeChangerStateEnum.DISABLED;
                    Flow = 0;
                    break;
            }
        }

        public string DisplayableWeather()
        {
            switch (TheWeather)
            {
                case WeatherEnum.DEWY:
                    return "dewy";
                case WeatherEnum.RAINY:
                    return "rainy";
                case WeatherEnum.STORMY:
                    return "stormy";
                case WeatherEnum.SUNNY:
                    return "sunny";
            }

            return string.Empty;
        }

        public override string ToString()
        {
            return string.Format("Weather: {0}\nWeather flow: {1}", DisplayableWeather(), Flow);
        }

    }
}
