using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace News.ProfileExecutor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PurchaseSubscription : ContentPage
    {
        public bool isOpenMenu = true;
        public List<Subscription> Subscriptions { get; set; }
        public PurchaseSubscription()
        {
            InitializeComponent();
            Subscriptions = new List<Subscription>
            {
                new Subscription{data="1 месяц", buns=new string[]{"+ceрвис"}, img=newImage("map.png"), price=280 },
                new Subscription{data="6 месяцев", buns=new string[]{"+скидка", "+ceрвис"}, img=newImage("SupportsNServices.png"), price=600 },
                new Subscription{data="12 месяцев", buns=new string[]{"+бонусы", "+скидка", "+ceрвис"}, img=newImage("SupportsNServices.png"), price=900 },
            };
            this.BindingContext = this;
        }
        public ImageSource newImage(string IconSource) { return ImageSource.FromResource(string.Format("News.image.{0}", IconSource)); }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfileExecutor.ConfirmationView(this), false);
        }
    }

    public class Subscription
    {
        public string data { get; set; }
        public int price { get; set; }
        public string[] buns { get; set; }
        public ImageSource img { get; set; }
    }
}