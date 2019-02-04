using System.Collections.Generic;
using System.Threading.Tasks;
namespace mobilePMP.Services
{
    public class InMemoryAccountRegistryService : IAccountRegistryService
    {
        public List<string> Accounts { get; set; }

        public InMemoryAccountRegistryService()
        {
            Accounts = new List<string>(GetDefaultAccounts());
        }

        public List<string> GetDefaultAccounts()
        {
            return new List<string>(new string[]
            {
                "bf070891f8ca03833162852dffcbc7016c7ed6d5ee775d1e69d1ba415fdd2a8c", // Test account with private keys
                "0xD63B7d06d8596908BA67d8401D35529b0BaB4E1d", // MEW Rinkeby for display balances
                "0x7EF676Be7fdE7AA929a1ecc908c6031e280f8834", //MTK Rinkeby for dislplay balances
            });

        }

        public List<string> GetRegisteredAccounts()
        {
            return Accounts;
        }

        public async Task RegisterAccountAddress(string address)
        {
            if (!Accounts.Exists(x => x.ToLower() == address.ToLower()))
            {
                Accounts.Add(address);
            }
        }
    }
}
