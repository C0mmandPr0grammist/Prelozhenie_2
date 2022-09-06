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
    public partial class CreateOrderPage : ContentPage
    {
        OrderList _orderList;
        bool edit;
        bool include = false;

        public List<Optional> optional { get; set; }
        public CreateOrderPage(OrderList orderList, bool isEdit)
        {
            edit = isEdit;
            _orderList = orderList;
            InitializeComponent();
            label_Category.Text = orderList.Category;
            optional = new List<Optional>
            {
                new Optional{Id = 0, Img = "tick.png", Text = "Стяжка"},
            };
            this.BindingContext = this;
        }

        private async void Back(object sender, EventArgs e)
        {
            if (edit)
            {
                await Navigation.PopAsync();
            }
            else
            {
                await Navigation.PopModalAsync();
            }

        }

        //private void ImageButton_Clicked(object sender, EventArgs e)
        //{
        //    if(edit == true)
        //    {
        //        tick.IsVisible = false;
        //        cross.IsVisible = true;
        //        empty.IsVisible = false;
        //        draw.IsVisible = true;
        //    }

        //}

        //private void ImageButton_Clicked2(object sender, EventArgs e)
        //{
        //    if(edit == true)
        //    {
        //        tick.IsVisible = true;
        //        cross.IsVisible = false;
        //        empty.IsVisible = true;
        //        draw.IsVisible = false;
        //    }

        //}

        private async void To_FinishOrder(object sender, EventArgs e)
        {
            if (edit)
            {
                await Navigation.PushAsync(new FinishOrder(_orderList));
            }
            else
            {
                await Navigation.PopModalAsync();
            }
        }


        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Optional selectedOption = e.Item as Optional;
            list.SelectedItem = null;
            if (include)
            {
                include = false;
                empty.IsVisible = false;
                selectedOption.Img = "tick.png";
                draw.IsVisible = true;
            }
            else
            {
                include = true;
                empty.IsVisible = true;
                selectedOption.Img = "cross.png";
                draw.IsVisible = false;
            }

            optional.Insert(0, selectedOption);
        }
    }

    public class Optional
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string Text { get; set; }
    }
}