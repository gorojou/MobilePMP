using System;

using Xamarin.Forms;

namespace mobilePMP.Interfaces
{
    public interface ICommand
    {
        void Execute(object arg);
        bool CanExecute(object arg);
        event EventHandler CanExecuteChanged; 
    } 
}

