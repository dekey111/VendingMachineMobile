using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendingMachineMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAutor : ContentPage
    {
        public PageAutor()
        {
            InitializeComponent();
        }

        private async void btnEnter_Clicked(object sender, EventArgs e)
        {
            if (Password.Text == "1111") 
            {
                PageMainDrinks mainDrinks = new PageMainDrinks();
                await Navigation.PushAsync(mainDrinks);
            }
            else
                lbError.Text = "Не верный пароль!";
            

        }
    }
}