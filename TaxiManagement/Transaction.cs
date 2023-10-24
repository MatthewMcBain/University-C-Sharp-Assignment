using System;

namespace TaxiManagement
{
    public abstract class Transaction
    {
        public DateTime TransactionDatetime { get; }
        public string TransactionType { get; }

        public Transaction(string type, DateTime dt)
        {
            this.TransactionType = type;
            this.TransactionDatetime = dt;
        }

        public abstract override string ToString();
    }
}
