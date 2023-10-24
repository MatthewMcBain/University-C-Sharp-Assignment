using System;

namespace TaxiManagement
{
    public class LeaveTransaction : Transaction
    {
        private int taxiNum;
        private int rankId;
        private string destination;
        private double agreedPrice;

        public LeaveTransaction(DateTime transactionDatetime, int rankId, Taxi t) : base("Leave", transactionDatetime)
        {
            this.rankId = rankId;
            this.taxiNum = t.Number;
            this.destination = t.Destination;
            this.agreedPrice = t.CurrentFare;
        }

        public override string ToString()
        {
            return base.TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + " Leave     - Taxi " + taxiNum + " from rank " + rankId + " to " + destination + " for £" + agreedPrice;
        }
    }
}
