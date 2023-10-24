using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagement
{
    public class TransactionManager
    {
        public List<Transaction> Transactions { get; } = new List<Transaction>();
        public void RecordDrop(int taxiNum, bool pricePaid)
        {
            Transaction transaction = new DropTransaction(DateTime.Now, taxiNum, pricePaid);
            Transactions.Add(transaction);
        }

        public void RecordJoin(int taxiNum, int rankId)
        {
            Transaction transaction = new JoinTransaction(DateTime.Now, taxiNum, rankId);
            Transactions.Add(transaction);
        }

        public void RecordLeave(int rankId, Taxi t)
        {
            Transaction transaction = new LeaveTransaction(DateTime.Now, rankId, t);
            Transactions.Add(transaction);
        }
    }
}
