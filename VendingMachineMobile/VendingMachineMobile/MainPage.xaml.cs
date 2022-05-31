using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineMobile.dataFiles;
using VendingMachineMobile.Pages;
using Xamarin.Forms;

namespace VendingMachineMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            // создание таблицы, если ее нет
            await App.Database.CreateTable();
            // привязка данных
            lvDrinks.ItemsSource = await App.Database.GetItemsAsync();
            base.OnAppearing();
        }

        private async void Drinks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Drinks selectedDrinks = (Drinks)e.SelectedItem;
            PageSellProduct saleDrinks = new PageSellProduct();
            saleDrinks.BindingContext = selectedDrinks;
            await Navigation.PushAsync(saleDrinks);
        }

        private async void btnAdmin_Clicked(object sender, EventArgs e)
        {
            PageAutor autor = new PageAutor();
            await Navigation.PushAsync(autor);
        }
    }
}
