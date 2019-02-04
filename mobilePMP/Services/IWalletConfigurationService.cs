
using Nethereum.JsonRpc.Client;
using Nethereum.Web3;

namespace mobilePMP.Services
{
    public interface IWalletConfigurationService
    {
        string ClientUrl { get; set; }

        bool IsConfigured();
        Web3 GetReadOnlyWeb3();
    }
}
