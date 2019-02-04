using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using mobilePMP.ViewModels;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace mobilePMP.Views
{
    public partial class RecibirPage : ContentPage
    {
        RecibirViewModel viewModel;

        public RecibirPage()
        {
            InitializeComponent();

            BindingContext = viewModel;

            Result();
        }

        protected void Result()
        {
            var barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 500;
            barcode.BarcodeOptions.Height = 500;
            barcode.BarcodeValue = "Igor Miquilena es @Goro";
            this.qrResult.Content = barcode;
        }


        public async void OnRecibirClicked(object sender, EventArgs e)
        {
           


            IUserDialogs Dialogs = UserDialogs.Instance;

            if (string.IsNullOrEmpty(montorecibirpmp.Text) == false)
            {
                Dialogs.ShowLoading("Procesando...");
                await Task.Delay(2000);
                Dialogs.HideLoading();

                Application.Current.Properties["SaldoRecibir"] = Double.Parse(montorecibirpmp.Text);
                    
                MainPage myHomePage = new MainPage();
                NavigationPage.SetHasNavigationBar(myHomePage, false);
                await Navigation.PushAsync(myHomePage);
                }else{

                          await DisplayAlert("Recibir","Monto no valido", "OK");
            }
          

        }
    }
}
