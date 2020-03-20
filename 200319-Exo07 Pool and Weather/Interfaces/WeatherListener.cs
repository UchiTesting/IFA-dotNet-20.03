using System;
using System.Collections.Generic;
using System.Text;

namespace _200319_Exo07_Pool_and_Weather.Interfaces
{
    interface WeatherListener
    {
        public void OnWeatherChange(object sender, EventArgs e);
    }
}
