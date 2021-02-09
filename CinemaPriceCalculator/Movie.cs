using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaPriceCalculator
{
    public class Movie
    {
        public string title { get; private set; }
        private List<MovieScreening> screenings;


        public Movie(string title)
        {
            this.title = title;
            screenings = new List<MovieScreening>();
        }


        public void addScreening(MovieScreening screening)
        {
            screenings.Add(screening);
        }

    }
}
