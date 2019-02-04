
using System;
using System.Collections.Generic;
using System.Text;
using mobilePMP.Services;
namespace mobilePMP.Services
{
    public class InMemoryKeySecureStorageService : IAccountKeySecureStorageService
    {
        private Dictionary<string, string> MockSecureStorage { get; set; }

        public InMemoryKeySecureStorageService()
        {
            MockSecureStorage = new Dictionary<string, string>();
            MockSecureStorage.Add("0xD63B7d06d8596908BA67d8401D35529b0BaB4E1d".ToLower(), "bf070891f8ca03833162852dffcbc7016c7ed6d5ee775d1e69d1ba415fdd2a8c");
        }

        public string GetPrivateKey(string account)
        {
            if (MockSecureStorage.ContainsKey(account.ToLower()))
            {
                return MockSecureStorage[account.ToLower()];
            }

            return null;
        }
    }
}
