using System;
namespace mobilePMP.Services
{
    public interface IAccountKeySecureStorageService
    {
        string GetPrivateKey(string account);
    }
}
