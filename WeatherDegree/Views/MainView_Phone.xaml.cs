﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDegree.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherDegree.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView_Phone : ContentPage
    {
        public MainView_Phone()
        {
            InitializeComponent();
            BindingContext = Resolver.Resolve<MainViewModel>();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is MainViewModel viewModel)
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await viewModel.LoadData();
                });
            }
        }
    }
}