﻿using News.Begin;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News
{
    public partial class App : Application
    {
        bool isCust = true;
        bool isAuth = false;
        public App()
        {
            InitializeComponent();

            if (isAuth)
            {


                if (isCust)
                {
                    MainPage = new NavigationPage(new Customer.MainPage());
                }
                else
                {
                    MainPage = new NavigationPage(new MainPage());
                }
            } else
            {
                MainPage = new NavigationPage(new _1());
            }
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
