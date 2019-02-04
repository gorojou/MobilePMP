﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using mobilePMP.Servicesapp;
using mobilePMP.Services;
using Xamarin.Forms;
namespace mobilePMP.ViewModels
{
    public class BalanceSummaryViewModel : BaseViewModel
    {
        private readonly IEthWalletService walletService;
        private readonly IAccountTokenViewModelMapperService accountTokenViewModelMapperService;

        private AccountTokenViewModel selectedToken;

        private ObservableCollection<AccountTokenViewModel> tokenBalanceSummary;

        public BalanceSummaryViewModel(IEthWalletService walletService,
            IAccountTokenViewModelMapperService accountTokenViewModelMapperService
            )
        {
            this.walletService = walletService;
            this.accountTokenViewModelMapperService = accountTokenViewModelMapperService;
            tokenBalanceSummary = new ObservableCollection<AccountTokenViewModel>();
            Title = "Balances";
            Icon = "Icon.png";
        }



        public ObservableCollection<AccountTokenViewModel> TokensBalanceSummary
        {
            get { return tokenBalanceSummary; }
            set
            {
                tokenBalanceSummary = value;
                RaisePropertyChanged(() => TokensBalanceSummary);
            }
        }



        public AccountTokenViewModel SelectedToken
        {
            get { return selectedToken; }
            set
            {
                selectedToken = value;
                RaisePropertyChanged(() => SelectedToken);
            }
        }

        public ICommand LoadItemsCommand
        {
            get { return new MvxAsyncCommand(() => LoadData()); }
        }

        public ICommand RefreshItemsCommand
        {
            get { return new MvxAsyncCommand(() => LoadData(true)); }
        }

        public override async void Start()
        {
            if (TokensBalanceSummary == null || TokensBalanceSummary.Count == 0)
            {
                await LoadData();
            }

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
                TokensBalanceSummary.Clear();
                foreach (var accountSummary in accountTokenViewModelMapperService.Map(walletSummary.EthBalanceSummary,
                walletSummary.TokenBalanceSummary))
                {
                    TokensBalanceSummary.Add(accountSummary);
                }
            }
            catch
            {
                error = true;
            }

            if (error)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "No se puede cargar el historico de la cuenta", "OK");
            }

            IsBusy = false;
        }
    }
}
