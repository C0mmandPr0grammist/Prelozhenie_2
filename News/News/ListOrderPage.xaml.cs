using News.Customer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public List<OrderList> currentOrders { get; set; }
        public ListOrderPage(double height)
        {
            InitializeComponent();
            currentOrders = new List<OrderList>
            {
                new OrderList{Img = "man.jpg", Address = "Проспект Мира 31", Price="2200р"},
                new OrderList{Img = "man.jpg", Address = "Проспект Ленина 34", Price="900р"},
                new OrderList{Img = "man.jpg", Address = "Улица Орехова 70", Price="1890р"},
                new OrderList{Img = "man.jpg", Address = "Улица Советская 16", Price="2000р"},
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

        private async void To_Chat(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Chat("man.png", "Василий"));
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           OrderList selectedOrder = e.Item as OrderList;
            list.SelectedItem = null;
            await Navigation.PushModalAsync(new CreateOrderPage(selectedOrder, false));
        }

        private async void Back(object sender, EventArgs e)
        {
            if (arrow_Btn.Rotation == 0)
            {
                arrow_Btn.RotateTo(180, 100);
                await Navigation.PopModalAsync();
            }
            else
            {
                await content_Page.TranslateTo(0, 0, 150);
                await arrow_Btn.RotateTo(0, 100);
                frame_Content.CornerRadius = 0;
            }
        }
    }

    public class CurrentOrder
    {
        public string Img { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
    }
}