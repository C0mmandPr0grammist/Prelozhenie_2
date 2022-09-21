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
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            content.FadeTo(1, 200);
            content.BackgroundColor = Color.FromRgba(0, 0, 0, .5);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            content.FadeTo(0, 200);
            await Navigation.PopModalAsync(false);
        }
    }
}