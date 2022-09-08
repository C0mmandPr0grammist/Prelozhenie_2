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
    public partial class ChangeRole : ContentPage
    {
        bool down = true;
        public ChangeRole()
        {
            
            InitializeComponent();
            hand.TranslationY = -80;
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                animationHand();
                return true;
            });
        }

        public async void animationHand()
        {
            if (down)
            {
                await hand.TranslateTo(0, -50, 500);
                down = false;
            }
            else
            {
                await hand.TranslateTo(0, -80, 500);
                down = true;
            }
        }
        private async void ExecutorOpen(object sender, TappedEventArgs e)
        {
            await content.FadeTo(0, 200);
            await Navigation.PushModalAsync(new Exec1(), false);
        }
        private async void Back(object sender, EventArgs e)
        {
            await content.FadeTo(0, 250);
            await Navigation.PopAsync();
        }
    }
}