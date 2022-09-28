using News.Education;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace News
{
    public partial class MainPage : ContentPage
    {
        public bool isOpenMenu = true;
        DateTime end;
        TimeSpan time;
        public MainPage(bool first)
        {
            InitializeComponent();
            if(first)
            {
                Navigation.PushModalAsync(new EducationExec1(), true);
            }
        }

        private async void Start_Timer(object sender, EventArgs e)
        {
            end = DateTime.Now.AddSeconds(10);
            Button_Timer.IsVisible = true;
            image_button.IsVisible = false;
            await Frame_Menu.ScaleTo(0, 150);
            Frame_Menu.IsVisible = false;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                time = end - DateTime.Now;
                Button_Timer.Text = time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
                if (time.Seconds == -1)
                {
                    Button_Timer.IsVisible = false;
                    image_button.IsVisible = true;
                    isOpenMenu = true;
                    image_button.Source = "frog.png";
                    return false;
                }
                return true;
            });
        }

        private async void OpenProfile(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new ProfilePage(content.Width), false);
        }

        private async void OpenSupport(object sender, EventArgs e)
        {
            double height = content.Height;
            await Navigation.PushModalAsync(new SupportPage(height));
        }

        private async void OpenListOrder(object sender, EventArgs e)
        {
            double height = content.Height;
            await Navigation.PushModalAsync(new ListOrderPage(height));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (isOpenMenu)
            {
                image_button.Source = "frog_tab.png";
                Frame_Menu.IsVisible = true;
                await Frame_Menu.ScaleTo(1, 150);
                isOpenMenu = false;
            }
            else
            {
                image_button.Source = "frog.png";
                await Frame_Menu.ScaleTo(0, 150);
                Frame_Menu.IsVisible = false;
                isOpenMenu = true;
            }
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    System.Environment.Exit(0);
        //    return true;
        //}
    }
}