﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using mobilePMP.Servicesapp;
using mobilePMP.Views;
using mobilePMP.Services;
using Xamarin.Forms;
namespace mobilePMP.ViewModels
{
    public class AccountsSummaryViewModel : BaseViewModel
    {
        private readonly IAccountSummaryViewModelMapperService accountSummaryViewModelMapperService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IEthWalletService walletService;

        private ObservableCollection<AccountSummaryViewModel> accountsSummary;

        private AccountSummaryViewModel selectedAccount;

        public AccountsSummaryViewModel(IEthWalletService walletService,
            IAccountSummaryViewModelMapperService accountSummaryViewModelMapperService,
            IMvxNavigationService navigationService)
        {
            this.walletService = walletService;
            this.accountSummaryViewModelMapperService = accountSummaryViewModelMapperService;
            _navigationService = navigationService;
            AccountsSummary = new ObservableCollection<AccountSummaryViewModel>();
            Title = "Cuentas";
            Icon = "Icon.png";
        }

        public ObservableCollection<AccountSummaryViewModel> AccountsSummary
        {
            get { return accountsSummary; }
            set
            {
                this.RaiseAndSetIfChanged(ref accountsSummary, value);
            }
        }

        public AccountSummaryViewModel SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedAccount, value);
                if (selectedAccount != null)
                    ShowSelectedAccountCommand.Execute(null);
            }
        }

        public ICommand RefreshItemsCommand
        {
            get { return new MvxAsyncCommand(async () => await LoadData(true)); }
        }

        public ICommand LoadItemsCommand
        {
            get { return new MvxAsyncCommand(async () => await LoadData()); }
        }


        public ICommand ShowSelectedAccountCommand
        {
            get
            {
                return new MvxAsyncCommand(async () => await _navigationService.Navigate<AccountBalanceSummaryViewModel, string>(SelectedAccount.Address));

            }
        }


        public override async void Start()
        {
            await LoadData();
            base.Start();
        }

        private async Task LoadData(bool forceRefresh = false)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var error = false;
            try
            {
                var walletSummary = await walletService.GetWalletSummary(forceRefresh);
                AccountsSummary.Clear();
                foreach (var accountSummary in accountSummaryViewModelMapperService.Map(walletSummary.AccountsInfo))
                {
                    AccountsSummary.Add(accountSummary);
                }
            }
            catch
            {
                error = true;
            }

            if (error)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "No se puede cargar las cuentas", "OK");
            }

            IsBusy = false;
        }
    }

}
