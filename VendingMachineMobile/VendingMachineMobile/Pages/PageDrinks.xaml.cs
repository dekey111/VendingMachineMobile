using System;
using VendingMachineMobile.dataFiles;
using Xamarin.Forms;


namespace VendingMachineMobile.Pages
{
    public partial class PageDrinks : ContentPage
    {
        public PageDrinks()
        {
            InitializeComponent();
        }
        private async void SaveDrinks(object sender, EventArgs e)
        {
            var drinks = (Drinks)BindingContext;
            if (!String.IsNullOrEmpty(drinks.Name))
            {
                await App.Database.SaveItemAsync(drinks);
            }
            await this.Navigation.PopAsync();
        }
        private async void DeleteDrinks(object sender, EventArgs e)
        {
            var drinks = (Drinks)BindingContext;
            await App.Database.DeleteItemAsync(drinks);
            await this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}