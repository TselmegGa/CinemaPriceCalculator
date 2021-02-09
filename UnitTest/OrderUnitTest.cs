using Microsoft.VisualStudio.TestTools.UnitTesting;
using CinemaPriceCalculator;
using System;

namespace UnitTest
{
    [TestClass]
    public class OrderUnitTest
    {
        double defaultPrice = 5;
        Movie starWarsMovie = new Movie("Star wars I");

        [TestMethod]
        public void singleOrderNonStudentMidWeekUnitTest()
        {

            MovieScreening movieScreening = new MovieScreening(starWarsMovie, new DateTime(2021, 02, 04), defaultPrice);
            MovieTicket movieTicket = new MovieTicket(movieScreening, false, 1, 1);

            Order order =  new Order(1, false);
            order.addSeatReservation(movieTicket);

            Assert.AreEqual(5, order.calculatePrice());            
        }

        [TestMethod]
        public void singleOrderStudentMidWeekUnitTest()
        {
            MovieScreening movieScreening = new MovieScreening(starWarsMovie, new DateTime(2021, 02, 04), defaultPrice);
            MovieTicket movieTicket = new MovieTicket(movieScreening, false, 1, 1);

            Order order = new Order(1, true);
            order.addSeatReservation(movieTicket);

            Assert.AreEqual(5, order.calculatePrice());
        }

        [TestMethod]
        public void multipleOrdersStudentMidWeekUnitTest()
        {
            MovieScreening movieScreening = new MovieScreening(starWarsMovie, new DateTime(2021, 02, 04), defaultPrice);

            Order order = new Order(1, true);
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 1));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 2));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 3));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 4));

            Assert.AreEqual(10, order.calculatePrice());

        }

        [TestMethod]
        public void multipleOrdersNonStudentMidWeekUnitTest()
        {
            MovieScreening movieScreening = new MovieScreening(starWarsMovie, new DateTime(2021, 02, 04), defaultPrice);

            Order order = new Order(1, false);
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 1));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 2));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 3));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 4));

            Assert.AreEqual(10, order.calculatePrice());
        }

        [TestMethod]
        public void singleOrderNonStudentWeekendUnitTest()
        {

            MovieScreening movieScreening = new MovieScreening(starWarsMovie, new DateTime(2021, 02, 13), defaultPrice);
            MovieTicket movieTicket = new MovieTicket(movieScreening, false, 1, 1);

            Order order = new Order(1, false);
            order.addSeatReservation(movieTicket);

            Assert.AreEqual(5, order.calculatePrice());

        }

        [TestMethod]
        public void singleOrderStudentWeekendUnitTest()
        {
            MovieScreening movieScreening = new MovieScreening(starWarsMovie, new DateTime(2021, 02, 13), defaultPrice);
            MovieTicket movieTicket = new MovieTicket(movieScreening, false, 1, 1);

            Order order = new Order(1, true);
            order.addSeatReservation(movieTicket);

            Assert.AreEqual(5, order.calculatePrice());
        }

        [TestMethod]
        public void multipleOrdersStudentWeekendUnitTest()
        {
            MovieScreening movieScreening = new MovieScreening(starWarsMovie, new DateTime(2021, 02, 13), defaultPrice);

            Order order = new Order(1, true);
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 1));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 2));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 3));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 4));

            Assert.AreEqual(20, order.calculatePrice());
        }

        [TestMethod]
        public void multipleOrdersnonStudentWeekendUnitTest()
        {
            MovieScreening movieScreening = new MovieScreening(starWarsMovie, new DateTime(2021, 02, 13), defaultPrice);

            Order order = new Order(1, false);
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 1));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 2));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 3));
            order.addSeatReservation(new MovieTicket(movieScreening, false, 1, 4));

            Assert.AreEqual(20, order.calculatePrice());
        }
    }
}
