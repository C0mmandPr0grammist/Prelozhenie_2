using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.Customer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinishOrder : ContentPage
    {
        OrderList _orderList;
        public FinishOrder(OrderList orderList)
        {
            _orderList = orderList;
            InitializeComponent();
            image_Source.Source = _orderList.Img;
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void To_Cassa(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateOrderPage(_orderList, true));
        }
    }
}