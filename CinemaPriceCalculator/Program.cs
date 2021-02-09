using System;

namespace CinemaPriceCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Order order = new Order(1, false);
            order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("Star wars I"), DateTime.Now, 5), true, 1, 1));
            order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("Star wars I"), DateTime.Now, 5), true, 1, 2));
            order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("Star wars I"), DateTime.Now, 5), true, 1, 3));
            order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("Star wars I"), DateTime.Now, 5), true, 1, 4));
            order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("Star wars I"), DateTime.Now, 5), true, 1, 5));
            order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("Star wars I"), DateTime.Now, 5), true, 1, 6));

            order.export(TicketExportFormat.CONSOLE);
            Console.WriteLine("Order Price: {0}" ,order.calculatePrice());
        }
    }
}
