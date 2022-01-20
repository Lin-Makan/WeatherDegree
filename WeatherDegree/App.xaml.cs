using System;
using TinyNavigationHelper.Abstraction;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherDegree
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Bootstrapper.Init();
            NavigationHelper.Current.SetRootView("MainView", true);
            MainPage = new NavigationPage(new MainView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
