using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using mobilePMP.ViewModels;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace mobilePMP.Views
{
    public partial class EnviarPage : ContentPage
    {
        TransferTokenViewModel viewModel;
        
        public EnviarPage()
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        private async void Scan()
        {
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) =>
            {
            // Stop scanning
            scanPage.IsScanning = false;

            // Pop the page and show the result
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PopAsync();
                await DisplayAlert("Codigo Escaneado", result.Text, "OK");
            });
            };

            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);
        }

        public async void OnEnviarClicked(object sender, EventArgs e)
        {
                IUserDialogs Dialogs = UserDialogs.Instance;

            if (string.IsNullOrEmpty(montoenviar.Text) == false)
            {
                Dialogs.ShowLoading("Enviando...");
                await Task.Delay(2000);
                Dialogs.HideLoading();

                Application.Current.Properties["SaldoEnviar"] = Double.Parse(montoenviar.Text);
             


                MainPage myHomePage = new MainPage();
                NavigationPage.SetHasNavigationBar(myHomePage, false);
                await Navigation.PushAsync(myHomePage);
           
            }else{

              await  DisplayAlert("Enviar","Monto no valido", "OK");
            }


        }
        public async void OnScannerClicked(object sender, EventArgs e)
        {
            IUserDialogs Dialogs = UserDialogs.Instance;

            Dialogs.ShowLoading("Espere...");
            await Task.Delay(2000);
            Dialogs.HideLoading();

            Scan();
            //await Navigation.PushAsync(new mobilePMP.Views.QRReaderPage());

        }

        protected  void OnViewModelSet()
        {
            viewModel
                .ConfirmTransfer
                .RegisterHandler(
                    async interaction =>
                    {
                        var sendToken = await this.DisplayAlert(
                            "Confirmar el Envio",
                             interaction.Input,
                            "YES",
                            "NO");

                        interaction.SetOutput(sendToken);
                    });
        }
    }
}
