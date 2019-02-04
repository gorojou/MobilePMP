using System.Collections.Generic;
using mobilePMP.ViewModels;
using mobilePMP.Models;

namespace mobilePMP.Servicesapp
{
    public interface IAccountTokenViewModelMapperService
    {
        List<AccountTokenViewModel> Map(List<AccountToken> accountTokens);
        List<AccountTokenViewModel> Map(EthAccountToken ethAccountToken, List<AccountToken> accountTokens);
    }
}
