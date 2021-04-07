using System;
using System.Collections.Generic;

namespace IBS.EntitiesLayer.Models
{
    public partial class Account
    {
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal? AvailableBalance { get; set; }
        public decimal? InterestAmount { get; set; }
        public DateTimeOffset? AccountCreationTime { get; set; }
        public string Id { get; set; }

    }
}
