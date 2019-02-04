
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mobilePMP.Models;

namespace mobilePMP.Services
{
    public class InMemoryTokenRegistryService : ITokenRegistryService
    {
        public List<ContractToken> ContractTokens { get; set; }

        public InMemoryTokenRegistryService()
        {
            ContractTokens = new List<ContractToken>(GetDefaultContractTokens());
        }

        public List<ContractToken> GetDefaultContractTokens()
        {
            return new List<ContractToken>(
                new[]
                {
                    new ContractToken() { Address = "0x7EF676Be7fdE7AA929a1ecc908c6031e280f8834", Name = "MTMK", NumberOfDecimalPlaces = 18, Symbol = "MTMK", ImgUrl="mtkIcon.png" },
                    //new ContractToken() { Address = "0xf74231e7d8eccffddd8da6ed6e4f3db4994a795d", Name = "Digix", NumberOfDecimalPlaces = 18, Symbol = "DGD", ImgUrl="digixIcon.png" },
                    //new ContractToken() { Address = "0x48c80F1f4D53D5951e5D5438B54Cba84f29F32a5", Name = "Augur", NumberOfDecimalPlaces = 18, Symbol = "REP", ImgUrl="augurIcon.png" },
                });

        }

        public List<ContractToken> GetRegisteredTokens()
        {
            return ContractTokens;
        }

        public async Task RegisterToken(ContractToken token)
        {
            if (!ContractTokens.Exists(x => x.Address.ToLower() == token.Address.ToLower()))
            {
                ContractTokens.Add(token);
            }
            else
            {
                var oldToken = ContractTokens.FirstOrDefault(x => x.Address.ToLower() == token.Address.ToLower());
                ContractTokens.Remove(oldToken);
                ContractTokens.Add(token);
            }
        }
    }
}
