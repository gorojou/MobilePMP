using System;
namespace mobilePMP.ViewModels
{
    public class RecibirViewModel : BaseViewModel
    {



        public RecibirViewModel()
        {
            Title = "Recibir";


        }
        double usd;
        double pmp;

        public double Usd
        {
            get
            {

                return usd;

            }
            set
            {


                usd = value;
                UpdateUsd();
                //OnPropertyChanged(nameof(Usd));
                //OnPropertyChanged(nameof(Pmp));


            }
        }


        public double Pmp
        {
            get
            {

                return pmp;

            }
            set
            {


                pmp = value;
                UpdateUsd();
                //OnPropertyChanged(nameof(Usd));
                //OnPropertyChanged(nameof(Pmp));


            }
        }

        private double UpdateUsd()
        {

            return Usd = Usd * Pmp / 2;
        }

    }
}

