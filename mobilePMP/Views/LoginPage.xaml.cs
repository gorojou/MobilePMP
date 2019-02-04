using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using mobilePMP.Helpers;
using mobilePMP.Models;
using Xamarin.Forms;

namespace mobilePMP.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }


        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            IUserDialogs Dialogs = UserDialogs.Instance;

            Dialogs.ShowLoading("Cargando...");
            await Task.Delay(2000);
            Dialogs.HideLoading();

            var user = new User
            {
                Username = "test",
                Password = "test"
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                

                MainPage myHomePage = new MainPage();


                NavigationPage.SetHasNavigationBar(myHomePage, false);

                await Navigation.PushAsync(myHomePage);
                App.IsUserLoggedIn = true;

                // REMEMBER LOGIN STATUS!
                Application.Current.Properties["IsLoggedIn"] = true;
                Settings.IsLoggedIn = true;


            }
            else
            {
                messageLabel.Text = "Su Login ha fallado";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Username && user.Password == Constants.Password;
        }
    }
}
