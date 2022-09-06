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
    public partial class SupportPage : ContentPage
    {
        public SupportPage(double height)
        {
            InitializeComponent();
            content_Page.TranslationY = height / 2 - 40;
            Top_content.HeightRequest = height / 2;
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
                            Frame_Support.CornerRadius = 15;
                            arrow_Btn.RotateTo(180, 100);
                        }
                        else
                        {
                            content_Page.TranslationY = 0;
                            Frame_Support.CornerRadius = 15;
                            arrow_Btn.RotateTo(0, 100);
                        }
                    }
                    else
                    {
                        content_Page.TranslationY += e.TotalY;
                        Frame_Support.CornerRadius = 15;
                        arrow_Btn.RotateTo(180, 100);
                    }
                    break;

                case GestureStatus.Completed:
                    if (content_Page.TranslationY > 350)
                    {
                        Navigation.PopModalAsync();
                    }
                    else
                    {
                        content_Page.TranslateTo(0, 0, 50, Easing.CubicOut);
                        arrow_Btn.RotateTo(0, 100);
                        Frame_Support.CornerRadius = 0;
                    }
                    break;
            }
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void To_chat(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Chat("frog.png", "Поддержка"));
        }
    }
}