using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.Education
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EducationCust2 : ContentPage
    {
        public EducationCust2()
        {
            InitializeComponent();
            content.BackgroundColor = Color.FromRgba(0, 0, 0, .5);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await content.FadeTo(0, 200);
            Application.Current.MainPage = new NavigationPage(new Customer.MainPage(false));
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}