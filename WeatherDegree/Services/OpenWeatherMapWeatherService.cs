using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Net.Http;
using WeatherDegree.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace WeatherDegree.Services
{
    public class OpenWeatherMapWeatherService : IWeatherService
    {
        private object lat;
        private object lon;
        private int units;
        private string appid;
        private int metric;
        private int lang;

        public async Task<Forecast> GetForecast(double latitude, double longitude)
        {
            var language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var apiKey = "2f0e91b4b3b735b1841a74e1036bc456";
            var uri = $"https://api.openweathermap.org/data/2.5/forecast?";
            lat = {latitude}
            lon = {longitude}
            units = metric & lang = {language}
            appid = "2f0e91b4b3b735b1841a74e1036bc456";

            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(uri);
            var data = JsonConvert.DeserializeObject<WeatherData>(result);
            var forecast = new Forecast()
            {
                City = data.city.name,
                Items = data.list.Select(x => new ForecastItem()
                {
                    DateTime = ToDateTime(x.dt),
                    Temperature = x.main.temp,
                    WindSpeed = x.wind.speed,
                    Description = x.weather.First().description,
                    Icon = $"http://openweathermap.org/img/w/{x.weather.First().icon}.png"
                }).ToList()
            };
            return forecast;
        }

        private DateTime ToDateTime(long dt)
        {
            throw new NotImplementedException();
        }
    }
}
