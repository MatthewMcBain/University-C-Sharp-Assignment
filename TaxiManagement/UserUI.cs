using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagement
{
    public class UserUI
    {
        private RankManager rankMgr;
        private TaxiManager taxiMgr;
        private TransactionManager transactionMgr;

        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        {
            rankMgr = rkMgr;
            taxiMgr = txMgr;
            transactionMgr = trMgr;
        }       

        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            List<string> list = new List<string>();
            Taxi taxi = taxiMgr.FindTaxi(taxiNum);
            if (taxi.Destination != "" && pricePaid is true)
            {
                taxi.DropFare(pricePaid);
                transactionMgr.RecordDrop(taxiNum, pricePaid);                
                list.Add("Taxi " + taxiNum + " has dropped its fare and the price was paid.");
            }
            else if (taxi.Destination == "" && pricePaid is false)
            {
                list.Add("Taxi " + taxiNum + " has not dropped its fare.");
            }
            else if (taxi.Destination != "" && pricePaid is false)
            {
                taxi.DropFare(pricePaid);
                transactionMgr.RecordDrop(taxiNum, pricePaid);                
                list.Add("Taxi " + taxiNum + " has dropped its fare and the price was not paid.");
            }
            return list;
        }

        public List<string> TaxiJoinsRank(int taxiNum, int rankId)
        {
            Taxi taxi = taxiMgr.CreateTaxi(taxiNum);
            List<string> list = new List<string>();
            if (rankMgr.AddTaxiToRank(taxi, rankId))
            {
                transactionMgr.RecordJoin(taxiNum, rankId);
                list.Add("Taxi " + taxiNum + " has joined rank " + rankId + ".");                
            }
            else
            {
                list.Add("Taxi " + taxiNum + " has not joined rank " + rankId + ".");
            }
            return list;
        }

        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            Taxi taxi = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);
            List<string> list = new List<string>();
            if (taxi != null)
            {
                transactionMgr.RecordLeave(rankId, taxi);
                list.Add("Taxi " + taxi.Number + " has left rank " + rankId + " to take a fare to " + destination + " for £" + agreedPrice + ".");
            }
            else
            {
                list.Add("Taxi has not left rank " + rankId + ".");
            }
            return list;
        }

        public List<string> ViewFinancialReport()
        {
            List<string> list = new List<string>();
            list.Add("Financial report");
            list.Add("================");
            if (taxiMgr.GetAllTaxis().Count() == 0)
            {
                list.Add("No taxis, so no money taken");
            }
            else
            {
                double total = 0;
                foreach (Taxi taxi in taxiMgr.GetAllTaxis().Values)
                {
                    total += taxi.TotalMoneyPaid;
                    list.Add("Taxi " + taxi.Number + "      " + string.Format("{0:0.00}", taxi.TotalMoneyPaid));                    
                }
                list.Add("           ======");
                list.Add("Total:       " + string.Format("{0:0.00}", total));
                list.Add("           ======");
            }
            return list;
        }

        public List<string> ViewTaxiLocations()
        {
            List<string> list = new List<string>();
            list.Add("Taxi locations");
            list.Add("==============");
            if (taxiMgr.GetAllTaxis().Count() == 0)
            {
                list.Add("No taxis");
            }
            else
            {
                foreach (Taxi taxi in taxiMgr.GetAllTaxis().Values)
                {                   
                    if (taxi.Location.Equals(Taxi.ON_ROAD) && taxi.Destination != "")
                    {
                        list.Add("Taxi " + taxi.Number + " is on the road to " + taxi.Destination);
                    }
                    else if (taxi.Location.Equals(Taxi.ON_ROAD) && taxi.Destination == "")
                    {
                        list.Add("Taxi " + taxi.Number + " is on the road");
                    }
                    else
                    {
                        list.Add("Taxi " + taxi.Number + " is in rank " + taxi.Rank.Id);
                    }
                }
            }            
            return list;
        }        

        public List<string> ViewTransactionLog()
        {
            List<string> list = new List<string>();
            list.Add("Transaction report");
            list.Add("==================");
            if (transactionMgr.Transactions.Count == 0)
            {
                list.Add("No transactions");
            }
            else
            {                
                foreach (Transaction transaction in transactionMgr.Transactions)
                {
                    list.Add(transaction.ToString());
                }                
            }
            return list;
        }
    }
}
