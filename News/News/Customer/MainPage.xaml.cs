using News.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.Customer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage(bool first)
        {
            InitializeComponent();
            if(first)
            {
                Navigation.PushModalAsync(new EducationCust1(), false);
            }
        }
        private async void OpenProfile(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Customer.ProfilePage());
        }

        private async void OpenSupport(object sender, EventArgs e)
        {
            double height = content.Height;
            await Navigation.PushModalAsync(new SupportPage(height));
        }

        private async void OpenListOrder(object sender, EventArgs e)
        {
            double height = content.Height;
            await Navigation.PushModalAsync(new Customer.History(height));
        }

        private async void image_button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderListPage());
        }
        protected override bool OnBackButtonPressed()
        {
            System.Environment.Exit(0);
            return true;
        }
    }

}
