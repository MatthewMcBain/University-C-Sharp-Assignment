using System;

namespace TaxiManagement
{
    public class JoinTransaction : Transaction
    {
        private int taxiNum;
        private int rankId;

        public JoinTransaction(DateTime transactionDatetime, int taxiNum, int rankId) : base("Join", transactionDatetime)
        {
            this.taxiNum = taxiNum;
            this.rankId = rankId;
        }

        public override string ToString()
        {
            return base.TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + " Join      - Taxi " + taxiNum + " in rank " + rankId;
        }
    }
}
