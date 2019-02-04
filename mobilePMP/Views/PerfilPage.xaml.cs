using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using mobilePMP.Helpers;
using static mobilePMP.Helpers.Intent;

namespace mobilePMP.Views
{
    public partial class PerfilPage : ContentPage
    {
        

        public PerfilPage()
        {
            InitializeComponent();

           // CameraButton.Clicked += CameraButton_Clicked;




            takePhoto.Clicked += async (sender, args) =>
            {
                Application.Current.Properties["FotoUsuario"] = "user.jpg";
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Sin Camara", ":( No hay camara disponible.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {

                    Directory = "Sample",
                    Name = "user.jpg",
                    PhotoSize = PhotoSize.Custom,
                    CustomPhotoSize = 90, //Resize to 90% of original
                    CompressionQuality = 92,
                    SaveToAlbum = true,
                    AllowCropping = true



                });

                if (file == null)
                    return;
                

      
              
               

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
                //await DisplayAlert("El archivo lo encontraras en:", file.GetStream().ToString(), "OK");

                await Navigation.PushAsync(new BalancePage());
            };


            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Fotos no soportadas", ":( Sin permiso para fotos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,


                });

                Application.Current.Properties["FotoUsuario"] = "user.jpg";

                if (file == null)
                    return;

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });


                await Navigation.PushAsync(new BalancePage());
            };



        }

  

        async void OnGoHomeClicked (object sender, EventArgs e){

            await Navigation.PushAsync(new BalancePage());
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var intent = NavigationImage.Intent;
            //var user = intent.GetObject<BalancePage>("user");
            //BindingContext = user;
        }
    }

}
