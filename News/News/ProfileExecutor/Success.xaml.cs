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
    public partial class Success : ContentPage
    {
        public Success()
        {
            InitializeComponent();
        }

        private async void animationView_OnFinishedAnimation(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}