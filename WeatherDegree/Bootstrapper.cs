using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using WeatherDegree.ViewModels;
using Xamarin.Forms;
using WeatherDegree.Services;

using WeatherDegree.Views;
using TinyNavigationHelper.Forms;

namespace WeatherDegree
{
    public class Bootstrapper
    {
        public static void Init()
        {
            var navigation = new FormsNavigationHelper();
            if (Device.Idiom == TargetIdiom.Phone)
            {
                navigation.RegisterView("MainView",
                typeof(MainView_Phone));
            }
            else
            {
                navigation.RegisterView("MainView", typeof(MainView));
            }

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType
            <OpenWeatherMapWeatherService>().As<IWeatherService>();
            containerBuilder.RegisterType<MainViewModel>();
            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
