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
    public partial class Agreement : ContentPage
    {
        public Agreement()
        {
            InitializeComponent();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}