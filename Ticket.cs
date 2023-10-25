using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class Ticket
    {
        private string ticketId;
        private Customer customer;
        private Flight flight;
        private List<Customer> customers;
        private static Random random = new Random();

        public Ticket()
        {
            // Initialize a list of customers and generate a random ticket ID.
            customers = new List<Customer>();
            ticketId = GenerateTicketId();
        }

        public string TicketID { get { return ticketId; } set { ticketId = value; } }
        public Flight Flight { get { return flight; } }
        public Customer Customer { get { return customer; } }

        public Ticket(string ticketID)
        {
            // Constructor to set the ticket ID and initialize the customer list.
            TicketID = ticketID;
            customers = new List<Customer>();
        }

        private string GenerateTicketId()
        {
            // Generate a random ticket ID with a combination of letters and numbers.
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomId = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomId;
        }

        public void SelectFlight(string seatID, string flightID, ListFlight listFlight)
        {
            // Select a flight for the ticket based on its title.
            flight = listFlight.GetSeatByID(seatID);

            if (flight == null)
            {
                Console.WriteLine("Invalid seat selection.");
                return;
            }

            // Gather customer information based on the selected movie.
            if (flight is EconomyClassflight economyClassflight)
            {
                Console.WriteLine("Your name:");
                string name = Console.ReadLine();
                Console.WriteLine("Your phone:");
                int phone = int.Parse(Console.ReadLine());  // Set the customer's age.
                Console.WriteLine("Your country:");
                string country = Console.ReadLine();
                Console.WriteLine("Your passport:");
                string passport = Console.ReadLine();
                Console.WriteLine("Your email:");
                string email = Console.ReadLine();
                Console.WriteLine("Your Age");
                int age = int.Parse(Console.ReadLine());

                if (flight != null)
                {
                    customer = new Customer(name, phone, country, passport, age);
                    customers.Add(customer);
                }
                else
                {
                    Console.WriteLine("Invalid seat selection.");
                }
            }
            else if (flight is BusinessClassflight businessClassflight)
            {
                Console.WriteLine("Your name:");
                string name = Console.ReadLine();
                Console.WriteLine("Your phone:");
                int phone = int.Parse(Console.ReadLine());  // Set the customer's age.
                Console.WriteLine("Your country:");
                string country = Console.ReadLine();
                Console.WriteLine("Your passport:");
                string passport = Console.ReadLine();
                Console.WriteLine("Your email:");
                string email = Console.ReadLine();
                Console.WriteLine("Your Age");
                int age = int.Parse(Console.ReadLine());
                if (flight != null)
                {
                    customer = new Customer(name, phone, country, passport, age);
                    customers.Add(customer);
                }
                else
                {
                    Console.WriteLine("Invalid seat selection.");
                }
            }
        }

        public void PrintTicketInformation()
        {
            // Print ticket information including Flight and customer details.
            if (Flight != null && Customer != null)
            {
                Console.WriteLine("Ticket Information:");
                Console.WriteLine("Ticket ID: " + TicketID);
                Console.WriteLine("Flight ID: " + Flight.FlightID);
                Console.WriteLine("From: " + flight.FromLocation);
                Console.WriteLine("To: " + flight.ToLocation);
                Console.WriteLine("Seat ID: " + Flight.SeatID);
                Console.WriteLine("Cabin: " + Flight.Cabin);
                Console.WriteLine("Customer Name: " + Customer.Name);
                Console.WriteLine("Customer Phone: " + Customer.Phone);
                Console.WriteLine("Customer Country: " + Customer.Country);
                Console.WriteLine("Customer Passport: " + Customer.Passport);
                Console.WriteLine("Customer Age: " + Customer.Age);
            }
            else
            {
                Console.WriteLine("No seat selected or customer information is missing.");
            }
        }
    }
}
