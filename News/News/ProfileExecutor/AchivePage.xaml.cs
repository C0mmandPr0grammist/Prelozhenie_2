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
    public partial class AchivePage : ContentPage
    {
        public AchivePage()
        {
            InitializeComponent();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}