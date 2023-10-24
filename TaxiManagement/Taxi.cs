using System;
namespace TaxiManagement
{
    public class Taxi
    {
        public static string IN_RANK = "in rank";
        public static string ON_ROAD = "on the road";
        public double CurrentFare { get; private set; }
        public string Destination { get; private set; } = "";
        public string Location { get; private set; } = ON_ROAD;
        public int Number { get; }
        public double TotalMoneyPaid { get; private set; }
        private Rank rank;
        public Rank Rank
        {
            get
            {
                return rank;
            }
            set
            {
                if (value is null)
                {
                    throw new Exception("Rank cannot be null");
                }

                else if (Destination is not "")
                {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }

                else
                {
                    rank = value;
                }

                if (Destination is "")
                {
                    Location = IN_RANK;
                }

                else
                {
                    Location = ON_ROAD;
                }

            }
        }

        public Taxi(int number)
        {
            Number = number;
        }

        public void AddFare(string destination, double agreedPrice)
        {     
            Destination = destination;
            Location = ON_ROAD;
            CurrentFare = agreedPrice;
            rank = null;
        }

        public void DropFare(bool priceWasPaid)
        {
            if (priceWasPaid is true)
            {
                Destination = "";
                TotalMoneyPaid += CurrentFare;
                CurrentFare = 0;
            }
        }
    }
}
