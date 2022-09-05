using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (content_Page.TranslationY <= 0)
                    {
                        if (e.TotalY > 0)
                        {
                            content_Page.TranslationY += e.TotalY;
                            frame_Profile.CornerRadius = 15;
                        }
                        else
                        {
                            content_Page.TranslationY = 0;
                            frame_Profile.CornerRadius = 15;
                        }
                    }
                    else
                    {
                        content_Page.TranslationY += e.TotalY;
                        frame_Profile.CornerRadius = 15;
                    }
                    break;

                case GestureStatus.Completed:
                    if (content_Page.TranslationY > 150)
                    {
                        Navigation.PopModalAsync();
                    }
                    else
                    {
                        content_Page.TranslateTo(0, 0, 50, Easing.CubicOut);
                        frame_Profile.CornerRadius = 0;
                    }
                    break;
            }
        }
    }
}