using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineMobile.dataFiles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendingMachineMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSellProduct : ContentPage
    {
        public PageSellProduct()
        {
            InitializeComponent();
        }
        private async void BuyProduct(object sender, EventArgs e)
        {
            var drinks = (Drinks)BindingContext;
            if (!String.IsNullOrEmpty(drinks.Name))
            {
                if (drinks.Count < int.Parse(Count.Text))
                    await DisplayAlert("Ошибка", "Выбранное количество больше чем имеется в автомате!", "OK");
                else
                {
                    drinks.Count = drinks.Count - int.Parse(Count.Text);
                    await App.Database.SaveItemAsync(drinks);
                    await DisplayAlert("Покупка напитка", $"Напиток: {drinks.Name} куплен", "OK");
                    await this.Navigation.PopAsync();
                }

            }
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Count.Text.Length > 0)
            {
              lSum.Text = "Сумма: " + (int.Parse(Count.Text) * int.Parse(Cost.Text)).ToString();
            }
            else
                lSum.Text = "Сумма:";
        }
    }
}