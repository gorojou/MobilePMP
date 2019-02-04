using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using mobilePMP.ViewModels;

using Xamarin.Forms;

namespace mobilePMP.Views
{
    public partial class AddTokenPage : ContentPage
    {
        TokenEntryViewModel viewModel;

        public AddTokenPage()
        {
            InitializeComponent();

            BindingContext = viewModel;
        }


        async void OnAddTokenButtonClicked(object sender, EventArgs e)
        {
            IUserDialogs Dialogs = UserDialogs.Instance;

            Dialogs.ShowLoading("Espere...");
            await Task.Delay(2000);
            Dialogs.HideLoading();

            MainPage myHomePage = new MainPage();
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            await Navigation.PushAsync(myHomePage);

           
        }
    }
}
