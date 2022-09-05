using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News
{
    public partial class App : Application
    {
        bool isCust = true;
        public App()
        {
            InitializeComponent();

            if(isCust)
            {
                MainPage = new NavigationPage(new Customer.MainPage());
            } else
            {
                MainPage = new NavigationPage(new MainPage());
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
