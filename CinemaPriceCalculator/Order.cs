using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;


namespace CinemaPriceCalculator
{
    public class Order
    {
        private int orderNr { get; }
        private Boolean isStudentOrder;

        private List<MovieTicket> tickets;

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
            this.tickets = new List<MovieTicket>();
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            tickets.Add(ticket);
        }

        public double calculatePrice()
        {
            double premiumTicketStudent = 2;
            double premiumTicket = 3;

            double totalPrice = 0;
            double ticketPrice = 0;
            for (int i = 0; i < tickets.Count; i++)
            {

                //Doordeweeks
                if(tickets[i].movieScreening.dateAndTime.DayOfWeek == DayOfWeek.Friday ||
                tickets[i].movieScreening.dateAndTime.DayOfWeek == DayOfWeek.Saturday ||
                tickets[i].movieScreening.dateAndTime.DayOfWeek == DayOfWeek.Sunday)
                {
                        //weekend
                        //Student krijgt groeps korting vanaf 6 of meer
                        if (isStudentOrder && tickets.Count >= 6)
                        {
                            ticketPrice += tickets[i].getPrice() * 0.9;
                        }
                        else
                        {
                            ticketPrice += tickets[i].getPrice();
                        }


                }
                else
                {
                        //2e ticket gratis
                        ticketPrice += calculatePriceSecondTicketFree(i);
                        //controlleer of i even of 0 dan moeten we een prijs maken. de oneven getallen zijn de 2e ticket deze is gratis.

                    }

                if (tickets[i].isPremiumTicket && ticketPrice>0)
                {
                    if (isStudentOrder)
                    {
                        if (tickets.Count >= 6)
                        {
                            ticketPrice += premiumTicketStudent*0.9;
                        }
                        else
                        {
                            ticketPrice += premiumTicketStudent;
                        }
                        
                    }
                    else
                    {
                        ticketPrice += premiumTicket;
                    }
                }

                totalPrice += ticketPrice;
                ticketPrice = 0;
            }

            return totalPrice;
        }

        private double calculatePriceSecondTicketFree(int index)
        {
            if (index % 2 == 0 || index == 0)
            {
                return tickets[index].getPrice();

            }
            return 0;
        }

        public void export(TicketExportFormat exportFormat)
        {
            // Bases on the string respresentations of the tickets (toString), write
            // the ticket to a file with naming convention Order_<orderNr>.txt of
            // Order_<orderNr>.json
            string fileName = "Order_" + orderNr;
            string fileContent = "";

            switch (exportFormat)
            {
                case TicketExportFormat.JSON:
                    fileName = fileName + ".json";
                    //TODO JSON CONVERT
                    fileContent = JsonSerializer.Serialize(tickets);
                    File.WriteAllText(fileName, fileContent);
                    break;
                case TicketExportFormat.PLAINTEXT:
                    fileName = fileName + ".txt";
                    fileContent = string.Join("\n", tickets);
                    File.WriteAllText(fileName, fileContent);
                    break;
                case TicketExportFormat.CONSOLE:
                    fileContent = string.Join("\n", tickets);
                    Console.WriteLine(fileContent);
                    break;
            }
        }


    }
}
