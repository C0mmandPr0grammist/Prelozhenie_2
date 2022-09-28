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
    public partial class EditProfile : ContentPage
    {
        int Count = 0;
        public EditProfile()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Length > 0)
            {
                One.BackgroundColor = Color.Green;
                Two_Input.IsEnabled = true;
                Count = 1;
            } else
            {
                One.BackgroundColor = Color.Transparent;
                Two_Input.IsEnabled= false;
                Count = 0;
            }
        }

        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                Two.BackgroundColor = Color.Green;
                Three_Input.IsEnabled = true;
                Count = 2;
            }
            else
            {
                Two.BackgroundColor = Color.Transparent;
                Three_Input.IsEnabled = false;
                Count = 1;
            }
        }

        private void Entry_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                Three.BackgroundColor = Color.Green;
                Four_Input.IsEnabled = true;
                Count = 3;
            }
            else
            {
                Three.BackgroundColor = Color.Transparent;
                Four_Input.IsEnabled = false;
                Count = 2;
            }
        }

        private void Entry_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                Four.BackgroundColor = Color.Green;
                Five_Input.IsEnabled = true;
                Count = 4;
            }
            else
            {
                Four.BackgroundColor = Color.Transparent;
                Five_Input.IsEnabled = false;
                Count = 3;
            }
        }

        private void Entry_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 0)
            {
                Five.BackgroundColor = Color.Green;
                button_Edit.IsEnabled = true;
                Count = 5;
            }
            else
            {
                Five.BackgroundColor = Color.Transparent;
                button_Edit.IsEnabled = false;
                Count = 4;
            }
        }

        private async void Back(object sender, EventArgs e) {
            await Navigation.PopAsync();
        }
    }
}