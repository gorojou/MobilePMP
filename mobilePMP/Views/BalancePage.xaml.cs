using System;
using System.Collections.Generic;
using mobilePMP.ViewModels;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using mobilePMP.Helpers;
using static mobilePMP.Helpers.Intent;

namespace mobilePMP.Views
{
    public partial class BalancePage : ContentPage
    {


        public Double saldopromedio;
        public string UserImage;

        public BalancePage()
        {
            InitializeComponent();

            //BalanceViewModel viewModel = new BalanceViewModel();
            //BindingContext = viewModel;
           
            saldoText.Text = "3.602";
            saldopromedio = Double.Parse(saldoText.Text);
            SaldoEnviar();
            SaldoRecibir();
            saldoText.Text = saldopromedio.ToString();

            saldoText.RotateTo(-20, 60, Easing.Linear);

            profilephoto.Source= "user.jpg";

            //var user = new PerfilPage();
            //var intent = NavigationImage.Intent;
           
            //intent.PutObject("user", user);

            //intent.StartIntent();
             


        }
        private Double SaldoEnviar()
        {

            if ((Application.Current.Properties.ContainsKey("SaldoEnviar") == true) && saldoText.Text != "0")
            {
                Double mEnviar = Double.Parse(Application.Current.Properties["SaldoEnviar"].ToString());

                return saldopromedio = saldopromedio - mEnviar;

            }
            else
            {
                return saldopromedio;
            }

        }

        private Double SaldoRecibir()
        {

            if ((Application.Current.Properties.ContainsKey("SaldoRecibir") == true) && saldoText.Text != "0")
            {
                Double mRecibir = Double.Parse(Application.Current.Properties["SaldoRecibir"].ToString());

                return saldopromedio = saldopromedio + mRecibir;

            }
            else
            {
                return saldopromedio;
            }

        }

        async void OnClickedPerfil (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage());

        }
    }
}
