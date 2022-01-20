using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDegree
{
    public interface IWeatherService
    {
        Task<Forecast> GetForecast(double latitude, double longitude);
    }
}
