﻿using System;
namespace mobilePMP.Models
{
    public class WalletTransaction
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Token { get; set; }
        public decimal Amount { get; set; }
    }
}
