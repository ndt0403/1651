using System;
using System.Collections.Generic;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class Admin
    {
        // Initialize class variables and objects.
        private Program program;              // An instance of the Program class.
        private ListFlight listFlight;        // A list to store flights.
        private ListTicket listTicket;        // A list to store tickets.
        private Ticket ticket;                // A single ticket object.
        private ListAirlineStaff listAirlineStaff; // A list to store airline staff members.

        public Admin()
        {
            program = new Program();           // Initialize the Program object.
            listFlight = new ListFlight();     // Initialize the flight list.
            listTicket = new ListTicket();     // Initialize the ticket list.
            ticket = new Ticket();             // Initialize the ticket object.
            listAirlineStaff = new ListAirlineStaff(); // Initialize the airline staff list.
        }

        // Display the main menu for the Admin.
        public void DisplayMenu()
        {
            bool isDisplayMenu = true;

            while (isDisplayMenu)
            {
                Console.WriteLine("1. Add Flights");          // Option to add flights.
                Console.WriteLine("2. Display Flights");      // Option to display flight information.
                Console.WriteLine("3. Remove Flights");       // Option to remove flights.
                Console.WriteLine("4. Sell Tickets");          // Option to sell tickets.
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("5. Logout");               // Option to log out.
                Console.ResetColor();
                Console.WriteLine("6. Add Airline Staff");     // Option to add airline staff.
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        listFlight.Add();                   // Call the method to add a new flight.
                        break;
                    case "2":
                        listFlight.DisplayFlight();         // Call the method to display flight information.
                        break;
                    case "3":
                        listFlight.DisplayFlight();         // Call the method to display flight information.
                        listFlight.Remove();                // Call the method to remove flights.
                        break;
                    case "4":
                        listFlight.DisplayFlight();         // Call the method to display flight information.
                        SellTickets();                      // Call the method to sell tickets.
                        break;
                    case "5":
                        isDisplayMenu = false;              // Log out and exit the menu loop.
                        LogOut();                           // Call the method to log out.
                        break;
                    case "6":
                        listAirlineStaff.Add();             // Call the method to add airline staff.
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again (1 to 6)."); // Display an error message for an invalid choice.
                        break;
                }
                Console.WriteLine();
            }
        }

        // Log out of the admin account.
        public void LogOut()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Logout successful!");     // Display a success message.
            Console.ResetColor();
            program.SetLoggedIn(false);                // Set the logged-in status to false.
        }

        // Method to handle the sale of tickets.
        private void SellTickets()
        {
            Console.WriteLine("What is Flight ID do you want: ");
            string flightIDSelected = Console.ReadLine();  // Get the selected flight ID.
            Flight selectedFlight = listFlight.GetFlightByID(flightIDSelected); // Get the flight by ID.

            if (selectedFlight == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Flight ID not found in the list."); // Display an error if the flight is not found.
                Console.ResetColor();
                return;
            }

            string seatIDSelected;
            Flight selectedSeat;

            do
            {
                Console.WriteLine("What is Seat ID do you want: ");
                seatIDSelected = Console.ReadLine();  // Get the selected seat ID.
                selectedSeat = listFlight.GetSeatByID(seatIDSelected); // Get the seat by ID.

                if (selectedSeat == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Seat ID not found in the list."); // Display an error if the seat is not found.
                    Console.ResetColor();
                }
            } while (selectedSeat == null);

            ticket.SelectFlight(seatIDSelected, flightIDSelected, listFlight); // Select the flight and seat for the ticket.
            ticket.PrintTicketInformation(); // Print ticket information.

            string choose;
            do
            {
                Console.WriteLine("1. You want to continue payment");  // Option to proceed with payment.
                Console.WriteLine("2. You want to change seat or flight"); // Option to change seat or flight.
                choose = Console.ReadLine();

                if (choose == "1")
                {
                    ProcessPayment(seatIDSelected); // Call the method to process payment.
                }
                else if (choose == "2")
                {
                    ChangeseatIDFlight(); // Call the method to change the seat or flight.
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // Set text color for an error message.
                    Console.WriteLine("Invalid choice.");
                    Console.ResetColor(); // Reset text color to the default.
                }
            } while (choose != "1" && choose != "2");
        }

        // Method to change the selected seat or flight.
        private void ChangeseatIDFlight()
        {
            // Prompt the user to select a new flight and print its information.
            listFlight.DisplayFlight();
            Console.WriteLine("What is Flight ID do you want to change:");
            string newflightIDSelected = Console.ReadLine();
            Flight selectedFlight = listFlight.GetFlightByID(newflightIDSelected); // Get the new flight by ID.

            if (selectedFlight == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Flight ID not found in the list."); // Display an error if the new flight is not found.
                Console.ResetColor();
                return;
            }

            string newseatIDSelected;
            Flight selectedSeat;

            do
            {
                Console.WriteLine("What is Seat ID do you want to change:");
                newseatIDSelected = Console.ReadLine();  // Get the new seat ID.
                selectedSeat = listFlight.GetSeatByID(newseatIDSelected); // Get the new seat by ID.

                if (selectedSeat == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Seat ID not found in the list."); // Display an error if the new seat is not found.
                    Console.ResetColor();
                }
            } while (selectedSeat == null);

            ticket.SelectFlight(newseatIDSelected, newflightIDSelected, listFlight); // Select the new flight and seat for the ticket.
            ticket.PrintTicketInformation(); // Print ticket information.

            string choose;
            do
            {
                // Check if the new selected flight exists.
                // Prompt the user to proceed with payment for the new flight.
                Console.WriteLine("1. You want to continue payment"); // Option to proceed with payment.
                Console.WriteLine("2. You want to change seat or flight"); // Option to change seat or flight.
                choose = Console.ReadLine();

                if (choose == "1")
                {
                    ProcessPayment(newseatIDSelected); // Call the method to process payment for the new selection.
                }
                else if (choose == "2")
                {
                    ChangeseatIDFlight(); // Call the method to change the seat or flight.
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // Set text color for an error message.
                    Console.WriteLine("Invalid choice.");
                    Console.ResetColor(); // Reset text color to the default.
                }
            } while (choose != "1" && choose != "2");
        }

        // Method to handle the payment process for the selected seat.
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
                Console.WriteLine("1. To print ticket");  // Option to print the ticket.
                Console.WriteLine("2. Remove ticket");    // Option to remove the ticket.
                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        payment.AssignTicket(ticket); // Call the method to assign the ticket and print payment information.
                        payment.PrintPaymentInformation();
                        validChoice = true;
                        break;
                    case "2":
                        // Remove a ticket from the payment and update payment information.
                        listTicket.RemoveTicket(ticket);
                        Console.ForegroundColor = ConsoleColor.Green; // Set text color for a success message.
                        Console.WriteLine("Remove ticket successfully");
                        Console.ResetColor(); // Reset text color to the default.
                        payment.PrintPaymentInformation();
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again (1 or 2)."); // Display an error for an invalid choice.
                        break;
                }
            }
        }
    }
}
