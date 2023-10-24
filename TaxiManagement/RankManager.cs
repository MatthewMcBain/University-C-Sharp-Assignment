using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagement
{
    public class RankManager
    {
        private Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();
        public RankManager()
        {
            ranks[1] = new Rank(1, 5);
            ranks[2] = new Rank(2, 2);
            ranks[3] = new Rank(3, 4);
        }

        public bool AddTaxiToRank(Taxi t, int rankId)
        {
            if (!(t.Location.Equals(Taxi.ON_ROAD) && t.Destination.Equals("")))
            {
                return false;
            }            

            else if (FindRank(rankId) is null)
            {
                return false;
            }

            else if (t.Destination != "")
            {
                return false;
            }

            else if (ranks[rankId].AddTaxi(t) is true)
            {
                return true;
            }
            return false;            
        }

        public Rank FindRank(int rankId)
        {
            if (ranks.ContainsKey(rankId))
            {
                Rank r = ranks[rankId];
                return r;
            }
            return null;
        }

        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {
            if (FindRank(rankId) is not null)
            {
                Taxi t = ranks[rankId].FrontTaxiTakesFare(destination, agreedPrice);
                return t;
            }
            return null;
        }
    }
}
