using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace mobilePMP.Views
{
    public partial class ConfirmPingPage : ContentPage
    {
        public ConfirmPingPage()
        {
            InitializeComponent();
        }

         void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 4)
            {
                pingEntry.Text = pingEntry.Text.Remove(1);

               
            }
        } 

        async void OnPingButtonClickedvoid  (object sender, EventArgs e)
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
