using System;
using System.Collections.Generic;
using System.Text;
using Nethereum.Web3;

namespace mobilePMP.Services
{
    public class WalletConfigurationService : IWalletConfigurationService
    {
        //defaulting to the rinkeby testnet

        public string ClientUrl { get; set; } = "https://rinkeby.io/";
        public bool IsConfigured()
        {
            return !string.IsNullOrEmpty(ClientUrl);
        }

        public Web3 GetReadOnlyWeb3()
        {
            return new Web3 (ClientUrl);
        }
    }
}
