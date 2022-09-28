using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace News.ProfileExecutor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationView : ContentPage
    {
        Page _page;
        public ConfirmationView(Page page)
        {
            InitializeComponent();
            content.BackgroundColor = Color.FromRgba(0, 0, 0, .4);
            content.ScaleTo(1, 300);
            _page = page;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await content.ScaleTo(0, 200);
            await _page.Navigation.PushAsync(new ProfilePage(_page.Width, true));
            await Navigation.PopModalAsync(false);
        }

        private async void Back(object sender, EventArgs e)
        {
            await content.ScaleTo(0, 200);
            await Navigation.PopModalAsync();
        }
    }
}