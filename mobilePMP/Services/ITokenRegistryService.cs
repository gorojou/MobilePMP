using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mobilePMP.Models;
namespace mobilePMP.Services
{
    public interface ITokenRegistryService
    {
        List<ContractToken> GetRegisteredTokens();
        Task RegisterToken(ContractToken token);
    }
}
