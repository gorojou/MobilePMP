using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace mobilePMP.Views
{
    public partial class PingPage : ContentPage
    {
        public PingPage()
        {
            InitializeComponent();
        }


         async void  OnGeneratePing(object sender, EventArgs e){

            Application.Current.Properties["PingCreado"]= true;

            IUserDialogs Dialogs = UserDialogs.Instance;

            Dialogs.ShowLoading("Creando Ping...");
            await Task.Delay(2000);
            Dialogs.HideLoading();

            MainPage myHomePage = new MainPage();


            NavigationPage.SetHasNavigationBar(myHomePage, false);

            await Navigation.PushAsync(myHomePage);


        }


    }
}
