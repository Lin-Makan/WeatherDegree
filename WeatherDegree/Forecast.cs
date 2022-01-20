using System;
using System.Collections.Generic;
using System.Text;
using WeatherDegree.Models;

namespace WeatherDegree
{
    public class Forecast
    {
        public string City { get; set; }
        public List<ForecastItem> Items { get; set; }
    }
}
