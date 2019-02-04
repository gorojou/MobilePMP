using System;
using Xamarin.Forms;
using mobilePMP.Views;
using Xamarin.Forms.Xaml;
using mobilePMP.Helpers;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace mobilePMP
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static MasterPage MD { get; set; }
        public static NavigationPage Detail { get; set; }

        public App()
        {
            InitializeComponent();



            if (Settings.IsLoggedIn)
            {
                if (Properties.ContainsKey("PingCreado") == true)
                {
                    ConfirmPingPage myHomePage = new ConfirmPingPage();


                    NavigationPage.SetHasNavigationBar(myHomePage, false);

                    MainPage = new NavigationPage(myHomePage);

                }else{


                    MainPage myHomePage = new MainPage();


                    NavigationPage.SetHasNavigationBar(myHomePage, false);

                    MainPage = new NavigationPage(myHomePage);



                }


               
            }
            else
            {
                


                MainPage = new NavigationPage(new LoginPage());


               
               


            }
        }

        protected override void OnStart()
        {
           
            // Handle when your app starts

            Xamarin.Forms.Application.Current.Properties.Clear();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
