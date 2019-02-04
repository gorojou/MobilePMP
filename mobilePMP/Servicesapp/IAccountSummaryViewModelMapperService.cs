using System.Collections.Generic;
using mobilePMP.ViewModels;
using mobilePMP.Models;

namespace mobilePMP.Servicesapp
{
    public interface IAccountSummaryViewModelMapperService
    {
        List<AccountSummaryViewModel> Map(List<AccountInfo> accountsInfo);
    }
}
