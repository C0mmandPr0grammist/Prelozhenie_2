using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.Begin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class _1 : ContentPage
    {
        public _1()
        {
            InitializeComponent();
            content.Opacity = 1;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await content.FadeTo(0, 200);
            await Navigation.PushAsync(new ChangeRole(), false);
            content.Opacity = 1;
        }
    }
}