using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lottie;
using Lottie.Forms;

namespace News
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        bool isBuy = true;
        public ProfilePage(double width, bool nowBuy = false)
        {
            InitializeComponent();
            frame_Profile.TranslateTo(0, 0, 600);
            stat1.WidthRequest = width / 2;
            stat2.WidthRequest = width / 2;
            if(isBuy)
            {
                paySubscription.IsVisible = false;
                trueSubscription.IsVisible = true;
            } else
            {
                paySubscription.IsVisible = true;
                trueSubscription.IsVisible = false;
            }

            if(nowBuy)
            {
                animationView.IsVisible = true;
                animationView.AutoPlay = true;
                paySubscription.IsVisible = false;
                trueSubscription.IsVisible = false;
                trueSubscription.Opacity = 0;
            } else
            {
                animationView.IsVisible = false;
            }
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void edit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileExecutor.EditProfile());
        }

        private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void animationView_OnFinishedAnimation(object sender, EventArgs e)
        {
            animationView.IsVisible = false;
            trueSubscription.IsVisible = true;
            await trueSubscription.FadeTo(1, 100);
        }

        private async void paySubscription_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileExecutor.PurchaseSubscription());
        }

        private async void OpenLeague(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileExecutor.LeaguePage());
        }

        private async void OpenAbout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileExecutor.AboutMe());
        }
        private async void OpenAchive(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileExecutor.AchievementsPage());
        }

        private async void OpenCard(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileExecutor.CardUp());
        }
    }
}