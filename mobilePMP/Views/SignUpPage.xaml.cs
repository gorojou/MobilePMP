using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using mobilePMP.Models;
using Acr.UserDialogs;
using System.Threading.Tasks;

namespace mobilePMP.Views
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text,
                Email = emailEntry.Text
            };

            // Sign up logic goes here

            IUserDialogs Dialogs = UserDialogs.Instance;

            Dialogs.ShowLoading("Espere...");
            await Task.Delay(2000);
            Dialogs.HideLoading();

            //var signUpSucceeded = AreDetailsValid(user);
            //if (signUpSucceeded)
            //{
            //    var rootPage = Navigation.NavigationStack.FirstOrDefault();
            //    if (rootPage != null)
            //    {
            //        App.IsUserLoggedIn = true;
            //        Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
            //        await Navigation.PopToRootAsync();
            //    }
            //}
            //else
            //{
            //    messageLabel.Text = "Su Registro ha fallado";
            //}

            await Navigation.PushAsync(new mobilePMP.Views.AddTokenPage());
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }
    }
}
