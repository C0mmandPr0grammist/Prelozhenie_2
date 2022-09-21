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
    public partial class OrderListPage : ContentPage
    {
        public List<OrderList> Order { get; set; }
        public OrderListPage()
        {
            InitializeComponent();
            Order = new List<OrderList>
            {
                new OrderList{Img="bath.png", Category="Замена ванны"},
                new OrderList{Img="toilet.png", Category="Замена унитаза"},
                new OrderList{Img="towel.png", Category="Полотенцесушитель"},
                new OrderList{Img="wash.png", Category="Умывальник"},
                new OrderList{Img="red_toilet.png", Category="Замена унитаза"},
                new OrderList{Img="red_toilet.png", Category="Замена унитаза"},
            };
            this.BindingContext = this;
        }
        private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            int count = Order.Where(s => s.Category.ToLower().Contains(e.NewTextValue)).Count();
            Stack_Visible.IsVisible = false;
            listOrder.ItemsSource = Order.Where(s => s.Category.ToLower().Contains(e.NewTextValue.ToLower()));
            if (count == 0)
            {
                search_Text.IsVisible = true;
            }
            else
            {
                search_Text.IsVisible = false;
            }
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void listOrder_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            OrderList selectedOrder = e.Item as OrderList;
            listOrder.SelectedItem = null;
            await Navigation.PushAsync(new CreateOrderPage(selectedOrder, true));
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Stack_Visible.IsVisible = false;
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            Stack_Visible.IsVisible = true;
        }
    }

    public class OrderList
    {
        public string Img { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Address { get; set; }
    }
}