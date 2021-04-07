using System;
using System.Collections.Generic;

#nullable disable

namespace IBS.PresentationLayer.Models
{
    public partial class Account
    {
        //public Account()
        //{
        //    Transactions = new HashSet<Transaction>();
        //}

        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal? AvailableBalance { get; set; }
        public decimal? InterestAmount { get; set; }
        public DateTimeOffset? AccountCreationTime { get; set; }
        public string Id { get; set; }

      //  public virtual AspNetUser IdNavigation { get; set; }
       // public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
