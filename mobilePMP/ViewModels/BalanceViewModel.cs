using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using mobilePMP.Interfaces;
using mobilePMP.Models;
using Xamarin.Forms;

namespace mobilePMP.ViewModels
{
    public class BalanceViewModel : BaseViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BalanceViewModel()
        {
            Title = "Balance";
            //Users = new ObservableCollection<User>();
            //LoadUserCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "PagoMovilPlus", async (obj, item) =>
            //{
            //    var _item = item as Item;
            //    Items.Add(_item);
            //    await DataStore.AddItemAsync(_item);
            //});

        }



        public Double saldopromedio = 3.602;

        public Double SaldoPromedio
        {

            set
            {
                
                saldopromedio = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SaldoPromedio"));

            }
            get
            {
                    
                    
                return saldopromedio;
            }
        }




        String userImage = "";

        public String UserImage
        {

            set
            {
                userImage = value;

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SaldoPromedio"));

            }
            get
            {

                if (Application.Current.Properties.ContainsKey("FotoUsuario") != false)
                {
                    userImage = Application.Current.Properties.ContainsKey("FotoUsuario").ToString();
                }
                else
                { userImage = "user.jpg"; }


                return userImage;
            }
        }

    }

   
}
