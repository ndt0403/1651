using System;
using System.Collections.Generic;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class Admin
    {
        private Program program;
        private ListFlight listFlight;  // Initialize a list to store flights.
        private ListTicket listTicket;  // Initialize a list to store tickets.
        private Ticket ticket;          // Initialize a single ticket object.
        private ListAirlineStaff listAirlineStaff;
        public Admin()
        {
            program = new Program();
            listFlight = new ListFlight();
            listTicket = new ListTicket();
            ticket = new Ticket();
            listAirlineStaff = new ListAirlineStaff();
        }

        public void DisplayMenu()
        {
            bool isDisplayMenu = true;

            while (isDisplayMenu)
            {
                Console.WriteLine("1. Add Flights");
                Console.WriteLine("2. Display Flights");
                Console.WriteLine("3. Remove Flights");
                Console.WriteLine("4. Sell Tickets");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("5. Logout");
                Console.ResetColor();
                Console.WriteLine("6. Add Airline Staff");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        listFlight.Add();
                        break;
                    case "2":
                        listFlight.DisplayFlight();
                        break;
                    case "3":
                        listFlight.DisplayFlight();
                        listFlight.Remove();
                        break;
                    case "4":
                        listFlight.DisplayFlight();
                        SellTickets();
                        break;
                    case "5":
                        isDisplayMenu = false;
                        LogOut();
                        break;
                    case "6":
                        listAirlineStaff.Add();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again (1 to 6).");
                        break;
                }
                Console.WriteLine();
            }
        }

        public void LogOut()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Logout successful!");
            Console.ResetColor();
            program.SetLoggedIn(false);
        }

        private void SellTickets()
        {
            Console.WriteLine("What is Flight ID do you want: ");
            string flightIDSelected = Console.ReadLine();
            Flight selectedFlight = listFlight.GetFlightByID(flightIDSelected);

            if (selectedFlight == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Flight ID not found in the list.");
                Console.ResetColor();
                return;
            }

            string seatIDSelected;
            Flight selectedSeat;

            do
            {
                Console.WriteLine("What is Seat ID do you want: ");
                seatIDSelected = Console.ReadLine();
                selectedSeat = listFlight.GetSeatByID(seatIDSelected);

                if (selectedSeat == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Seat ID not found in the list.");
                    Console.ResetColor();
                }
            } while (selectedSeat == null);

            ticket.SelectFlight(seatIDSelected, flightIDSelected, listFlight);
            ticket.PrintTicketInformation();

            string choose;
            do
            {
                Console.WriteLine("1. You want to continue payment");
                Console.WriteLine("2. You want to change seat or flight");
                choose = Console.ReadLine();

                if (choose == "1")
                {
                    ProcessPayment(seatIDSelected);
                }
                else if (choose == "2")
                {
                    ChangeseatIDFlight();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // Set text color
                    Console.WriteLine("Invalid choice.");
                    Console.ResetColor(); // Reset text color to the default
                }
            } while (choose != "1" && choose != "2");
        }

        private void ChangeseatIDFlight()
        {
            // Prompt the user to select a new flight and print its information.
            listFlight.DisplayFlight();
            Console.WriteLine("What is Flight ID do you want to change:");
            string newflightIDSelected = Console.ReadLine();
            Flight selectedFlight = listFlight.GetFlightByID(newflightIDSelected);

            if (selectedFlight == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Flight ID not found in the list.");
                Console.ResetColor();
                return;
            }

            string newseatIDSelected;
            Flight selectedSeat;

            do
            {
                Console.WriteLine("What is Seat ID do you want to change:");
                newseatIDSelected = Console.ReadLine();
                selectedSeat = listFlight.GetSeatByID(newseatIDSelected);

                if (selectedSeat == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Seat ID not found in the list.");
                    Console.ResetColor();
                }
            } while (selectedSeat == null);

            ticket.SelectFlight(newseatIDSelected, newflightIDSelected, listFlight);
            ticket.PrintTicketInformation();

            string choose;
            do
            {
                // Check if the new selected flight exists.
                // Prompt the user to proceed with payment for the new flight.
                Console.WriteLine("1. You want to continue payment");
                Console.WriteLine("2. You want to change seat or flight");
                choose = Console.ReadLine();

                if (choose == "1")
                {
                    ProcessPayment(newseatIDSelected);
                }
                else if (choose == "2")
                {
                    ChangeseatIDFlight();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // Set text color
                    Console.WriteLine("Invalid choice.");
                    Console.ResetColor(); // Reset text color to the default
                }
            } while (choose != "1" && choose != "2");
        }

        // The ProcessPayment method handles payment for the selected flight.
        private void ProcessPayment(string seatIDSelected)
        {
            // Prompt the user for a payment ID and create a payment object.
            Console.WriteLine("Payment ID:");
            string paymentID = Console.ReadLine();
            Payment payment = new Payment(paymentID, DateTime.Now);

            // Prompt the user for the number of tickets they want to purchase.
            int numberOfTickets = 1;
            Console.WriteLine("You will buy " + numberOfTickets + " " + " Seat ID " + seatIDSelected + " ticket");

            bool validChoice = false;
            while (!validChoice)
            {
                // Provide options to proceed with payment, assign tickets, and print payment information.
                Console.WriteLine("1. To print ticket");
                Console.WriteLine("2. Remove ticket");
                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        payment.AssignTicket(ticket);
                        payment.PrintPaymentInformation();
                        validChoice = true;
                        break;
                    case "2":
                        // Remove a ticket from the payment and update payment information.
                        listTicket.RemoveTicket(ticket);
                        Console.ForegroundColor = ConsoleColor.Green; // Set text color
                        Console.WriteLine("Remove ticket successfully");
                        Console.ResetColor(); // Reset text color to the default
                        payment.PrintPaymentInformation();
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again (1 or 2).");
                        break;
                }
            }
        }
    }
}
