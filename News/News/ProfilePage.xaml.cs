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
            }
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
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

        //private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        //{
        //    switch (e.StatusType)
        //    {
        //        case GestureStatus.Running:
        //            if (content_Page.TranslationY <= 0)
        //            {
        //                if (e.TotalY > 0)
        //                {
        //                    content_Page.TranslationY += e.TotalY;
        //                    frame_Profile.CornerRadius = 15;
        //                }
        //                else
        //                {
        //                    content_Page.TranslationY = 0;
        //                    frame_Profile.CornerRadius = 15;
        //                }
        //            }
        //            else
        //            {
        //                content_Page.TranslationY += e.TotalY;
        //                frame_Profile.CornerRadius = 15;
        //            }
        //            break;

        //        case GestureStatus.Completed:
        //            if (content_Page.TranslationY > 150)
        //            {
        //                arrowBtn.RotateTo(180, 100);
        //                Navigation.PopModalAsync();
        //            }
        //            else
        //            {
        //                content_Page.TranslateTo(0, 0, 50, Easing.CubicOut);
        //                arrowBtn.RotateTo(0, 100);
        //                frame_Profile.CornerRadius = 0;
        //            }
        //            break;
        //    }
        //}
    }
}