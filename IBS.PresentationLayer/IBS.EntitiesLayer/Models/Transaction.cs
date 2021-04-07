using System;
using System.Collections.Generic;

#nullable disable

namespace IBS.EntitiesLayer.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public DateTimeOffset TransactionDateTime { get; set; }
        public string TransactionFrom { get; set; }
        public string TransactionTo { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
        public string AccountNumber { get; set; }
    }
}
