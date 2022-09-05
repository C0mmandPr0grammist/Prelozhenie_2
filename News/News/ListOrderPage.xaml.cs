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
    public partial class ListOrderPage : ContentPage
    {

        public List<CurrentOrder> currentOrders { get; set; }
        public ListOrderPage(double height)
        {
            InitializeComponent();
            currentOrders = new List<CurrentOrder>
            {
                new CurrentOrder{Img = "man.png", Address = "Проспект Мира 31", Price="2200р"},
                new CurrentOrder{Img = "man.png", Address = "Проспект Ленина 34", Price="900р"},
                new CurrentOrder{Img = "man.png", Address = "Улица Орехова 70", Price="1890р"},
                new CurrentOrder{Img = "man.png", Address = "Улица Советская 16", Price="2000р"},
            };
            this.BindingContext = this;
            content_Page.TranslationY = height / 2;

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
                            frame_Content.CornerRadius = 15;
                            arrow_Btn.RotateTo(180, 100);
                        }
                        else
                        {
                            content_Page.TranslationY = 0;
                            frame_Content.CornerRadius = 0;
                            arrow_Btn.RotateTo(0, 100);
                        }
                    }
                    else
                    {
                        content_Page.TranslationY += e.TotalY;
                        frame_Content.CornerRadius = 15;
                        arrow_Btn.RotateTo(180, 100);
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
                        arrow_Btn.RotateTo(0, 100);
                    }
                    break;
            }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CurrentOrder selectedOrder = e.Item as CurrentOrder;
            list.SelectedItem = null;
            //await Navigation.PushModalAsync(new Specific_OrderPage(selectedOrder));
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }

    public class CurrentOrder
    {
        public string Img { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
    }
}