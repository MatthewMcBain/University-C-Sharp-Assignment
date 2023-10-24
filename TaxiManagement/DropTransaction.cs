using System;

namespace TaxiManagement
{
    public class DropTransaction : Transaction
    {
        private int taxiNum;
        private bool priceWasPaid;

        public DropTransaction(DateTime transactionDatetime, int taxiNum, bool priceWasPaid) : base("Drop fare", transactionDatetime)
        {
            this.taxiNum = taxiNum;
            this.priceWasPaid = priceWasPaid;
        }

        public override string ToString()
        {
            if (priceWasPaid is true)
            {
                return base.TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + " Drop fare - Taxi " + taxiNum + ", price was paid";
            }
            else
            {
                return base.TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + " Drop fare - Taxi " + taxiNum + ", price was not paid";
            }
            
        }
    }
}
