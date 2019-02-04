using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace mobilePMP.ViewModels
{
    public class EnviarViewModel : BaseViewModel
    {
        public EnviarViewModel()
        {
            Title = "Enviar";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://pmplus.io")));
        }

        public ICommand OpenWebCommand { get; }
    }
}
