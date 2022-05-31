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
    public partial class PageMainDrinks : ContentPage
    {
        public PageMainDrinks()
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

        private async void lvDrinks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Drinks selectedDrinks = (Drinks)e.SelectedItem;
            PageDrinks drinksPage = new PageDrinks();
            drinksPage.BindingContext = selectedDrinks;
            await Navigation.PushAsync(drinksPage);
        }

        private async void btnAddDrinks_Clicked(object sender, EventArgs e)
        {
            Drinks drinks = new Drinks();
            PageDrinks drinksPage = new PageDrinks();
            drinksPage.BindingContext = drinks;
            await Navigation.PushAsync(drinksPage);
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {

        }
    }
}