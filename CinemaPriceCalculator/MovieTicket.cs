using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaPriceCalculator
{
    public class MovieTicket
    {

        public MovieScreening movieScreening { get; private set; }
        public Boolean isPremiumTicket { get; private set; }

        public int seatRow { get; private set; }
        public int seatNr { get; private set; }

        public MovieTicket(MovieScreening movieScreening, bool isPremiumTicket, int seatRow, int seatNr)
        {
            this.movieScreening = movieScreening;
            this.isPremiumTicket = isPremiumTicket;
            this.seatRow = seatRow;
            this.seatNr = seatNr;
        }

        

        public double getPrice()
        {
            return movieScreening.getPricePerSeat();
        }

        public override string ToString()
        {
            return movieScreening.ToString() + " - row " + seatRow + ", seat " + seatNr +
               (isPremiumTicket ? " (Premium)" : "");
        }
    }
}
