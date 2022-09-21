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
    public partial class Cust1 : ContentPage
    {
        public Cust1()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Customer.MainPage(true));
        }
    }
}