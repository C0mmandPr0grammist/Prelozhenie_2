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
    public partial class History : ContentPage
    {
        public List<OrderList> Order { get; set; }
        public History(double height)
        {
            InitializeComponent();

            Order = new List<OrderList>
            {
                new OrderList{Img="bath.png", Category="Замена ванны"},
                new OrderList{Img="toilet.png", Category="Замена унитаза"},
            };
            this.BindingContext = this;
            contentOrder.TranslationY = height / 2;
        }

        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (contentOrder.TranslationY <= 0)
                    {
                        if (e.TotalY > 0)
                        {
                            contentOrder.TranslationY += e.TotalY;
                            frame_Order.CornerRadius = 15;
                            await arrow_Btn.RotateTo(180, 100);
                        }
                        else
                        {
                            contentOrder.TranslationY = 0;
                            frame_Order.CornerRadius = 15;
                            await arrow_Btn.RotateTo(0, 100);
                        }
                    }
                    else
                    {
                        contentOrder.TranslationY += e.TotalY;
                        frame_Order.CornerRadius = 15;
                        await arrow_Btn.RotateTo(180, 100);
                    }
                    break;

                case GestureStatus.Completed:
                    if (contentOrder.TranslationY > 150)
                    {
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        await contentOrder.TranslateTo(0, 0, 50, Easing.CubicOut);
                        frame_Order.CornerRadius = 0;
                        await arrow_Btn.RotateTo(0, 100);
                    }
                    break;
            }
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            OrderList selectedOrder = e.Item as OrderList;
            list.SelectedItem = null;
        }
    }

    
}