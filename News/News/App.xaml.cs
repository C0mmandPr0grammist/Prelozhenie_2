using News.Begin;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News
{
    public partial class App : Application
    {
        bool isCust = false;
        bool isAuth = true;
        public App()
        {
            InitializeComponent();

            if (isAuth)
            {


                if (isCust)
                {
                    MainPage = new NavigationPage(new Customer.MainPage(false));
                }
                else
                {
                    MainPage = new NavigationPage(new MainPage(false));
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
