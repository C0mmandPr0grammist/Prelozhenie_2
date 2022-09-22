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
    public partial class PurchaseSubscription : ContentPage
    {
        public List<Subscription> Subscriptions { get; set; }
        public PurchaseSubscription()
        {
            InitializeComponent();
            Subscriptions = new List<Subscription>
            {
                new Subscription{data="1 месяц", buns=new string[]{"+ceрвис"}, img="shield.png", price=280 },
                new Subscription{data="6 месяцев", buns=new string[]{"+скидка", "+ceрвис"}, img="shield_gray.png", price=600 },
                new Subscription{data="12 месяцев", buns=new string[]{"+бонусы", "+скидка", "+ceрвис"}, img="shield_orange.png", price=900 },
            };
            this.BindingContext = this;
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    public class Subscription
    {
        public string data { get; set; }
        public int price { get; set; }
        public string[] buns { get; set; }
        public string img { get; set; }
    }
}