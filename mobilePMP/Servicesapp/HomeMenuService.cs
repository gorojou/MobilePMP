using System;
using System.Collections.Generic;
using mobilePMP.Modelsapp;
using mobilePMP.ViewModels;

namespace mobilePMP.Servicesapp
{
    public class HomeMenuService : IHomeMenuService
    {
        public List<ShellMenuItem> GetMenuItems()
        {
            return new List<ShellMenuItem>
            {
                //new ShellMenuItem {Title = "Balance", PageViewModelType = typeof (BalanceSummaryViewModel), IconSource = "icon.png"},
                //new ShellMenuItem {Title = "Cuentas", PageViewModelType = typeof (AccountsSummaryViewModel), IconSource = "icon.png"},
                //new ShellMenuItem {Title = "Transfer Token", PageViewModelType = typeof (TransferTokenViewModel), IconSource = "icon.png"},
                //new ShellMenuItem {Title = "Agregar Token", PageViewModelType = typeof (TokenEntryViewModel), IconSource = "ethIcon.png"},
                //new ShellMenuItem {Title = "Transacciones", PageViewModelType = typeof (TransactionHistoryViewModel), IconSource = "micon.png"}


            };
        }
    }
}
