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
    public partial class EducationCust1 : ContentPage
    {
        public EducationCust1()
        {
            InitializeComponent();
            content.BackgroundColor = Color.FromRgba(0, 0, 0, .5);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await content.FadeTo(0, 250);
            await Navigation.PushModalAsync(new EducationCust2(), false);
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}