using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaPriceCalculator
{
    public class MovieScreening
    {
        public Movie movie { get; private set; }

        public DateTime dateAndTime { get; private set; }
        private Double pricePerSeat;



        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.movie = movie;
            movie.addScreening(this);

            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }

        public double getPricePerSeat()
        {
            return pricePerSeat;
        }

        public override string ToString()
        {
            return movie.title + " - " + dateAndTime;
        }
    }
}
