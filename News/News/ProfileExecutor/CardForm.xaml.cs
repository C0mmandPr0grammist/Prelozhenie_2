using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.ProfileExecutor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardForm : ContentPage
    {
        public CardForm()
        {
            InitializeComponent();
        }
        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void One_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Length == 4)
            {
                One.Text += "   ";
            } else if (e.NewTextValue.Length == 11)
            {
                One.Text += "   ";
            } else if (e.NewTextValue.Length == 18)
            {
                One.Text += "   ";
            } else if(e.NewTextValue.Length == 25)
            {
                nameCard.Focus();
            }
        }

        private void nameCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            nameCard.Text = e.NewTextValue.ToUpper();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Length == 2)
            {
                dataEntry.Focus();
            }
        }

        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Length == 2) {
                cvv.Focus();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileExecutor.Success());
        }
    }
}