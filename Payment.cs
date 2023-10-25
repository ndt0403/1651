using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class Payment
    {
        private ListFlight listFlight;
        private string paymentId;
        private decimal amount;
        private DateTime paymentDate;
        private ListTicket listTicket;

        public string PaymentID
        {
            get { return paymentId; }
            set { paymentId = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public ListTicket ListTicket
        {
            get { return listTicket; }
            set { listTicket = value; }
        }

    

        public Payment(string paymentID, DateTime paymentDate)
        {
            // Constructor to initialize payment information.
            PaymentID = paymentID;
            Amount = 100; // Default ticket amount (you may modify this value).
            PaymentDate = paymentDate;
            ListTicket = new ListTicket();
        }

        public Payment()
        {
            // Default constructor.
        }

        public void AssignTicket(Ticket ticket)
        {
            // Method to associate a ticket with the payment.
            ListTicket.AddTicket(ticket);
        }

        

        public void PrintPaymentInformation()
        {
            // Method to print payment and ticket details.
            Console.WriteLine("--------------------");
            Console.WriteLine("Payment Information:");
            Console.WriteLine("Payment ID: " + PaymentID);
            Console.WriteLine("Payment Date: " + PaymentDate);
            Console.WriteLine("--------------------");

            List<Ticket> tickets = ListTicket.GetTickets();

            if (tickets.Count > 0)
            {
                Console.WriteLine("Tickets:");

                foreach (Ticket ticket in tickets)
                {
                    // Display information for each associated ticket.
                    Console.WriteLine("Ticket ID: " + ticket.TicketID);
                    Console.WriteLine("From: " + ticket.Flight.FromLocation);
                    Console.WriteLine("To: " + ticket.Flight.ToLocation);
                    Console.WriteLine("Seat ID: " + ticket.Flight.SeatID);
                    Console.WriteLine("Cabin: " + ticket.Flight.Cabin);
                    Console.WriteLine("Name's Customer: " + ticket.Customer.Name);
                    Console.WriteLine("Phone's Customer: " + ticket.Customer.Phone);
                    Console.WriteLine("Country's Customer: " + ticket.Customer.Country);
                    Console.WriteLine("Passport's Customer: " + ticket.Customer.Passport);
                    Console.WriteLine("Age's Customer: " + ticket.Customer.Age);
                }

                Console.WriteLine("Total Amount: " + Amount + " dollar");
                Console.WriteLine("--------------------");
            }
            else
            {
                Console.WriteLine("No associated tickets.");
                Console.WriteLine("--------------------");
            }
        }
        /*public void RemoveTicket(Ticket ticket)
        {
            // Method to disassociate a ticket from the payment.
            ListTicket.RemoveTicket(ticket);
        }*/
    }
}
