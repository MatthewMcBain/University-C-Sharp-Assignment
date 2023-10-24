using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManagement
{
    public class TaxiManager
    {
        private SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();

        public Taxi CreateTaxi(int taxiNum)
        {            
            if (FindTaxi(taxiNum) is null)
            {
                Taxi t = new Taxi(taxiNum);
                taxis.Add(taxiNum, t);
                return t;
            }
            else
            {
                Taxi t = FindTaxi(taxiNum);
                return t;
            }
            
        }

        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }

        public Taxi FindTaxi(int taxiNum)
        {
            if (taxis.ContainsKey(taxiNum))
            {
                Taxi t = taxis[taxiNum];
                return t;
            }
            else
            {
                return null;
            }
        }
    }
}