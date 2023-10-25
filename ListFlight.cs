﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class ListFlight : InterfaceData
    {
        private List<Flight> flights;
        EconomyClassflight economyClassflight = new EconomyClassflight();
        BusinessClassflight businessClassflight = new BusinessClassflight();

        public ListFlight()
        {
            flights = new List<Flight>();
        }

        public void DisplayFlight()
        {
            // Display information for each flight in the list.
            foreach (Flight flight in flights)
            {
                flight.displayInformation();
            }
        }

        public void Add()
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Flight ID:");
                    string flightID = Console.ReadLine();
                 
                    if (!CheckFlight(flightID))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Flight ID already exists. Please enter a unique Flight ID.");
                        Console.ResetColor();
                        continue;
                    }

                    Flight newFlight = new Flight();
                    newFlight.FlightID = flightID;

                    Console.WriteLine("Enter From Location:");
                    newFlight.FromLocation = Console.ReadLine();

                    Console.WriteLine("Enter To Location:");
                    newFlight.ToLocation = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newFlight.FromLocation) || string.IsNullOrWhiteSpace(newFlight.ToLocation))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("From Location and To Location cannot be empty. Please enter them.");
                        Console.ResetColor();
                        continue;
                    }

                    flights.Add(newFlight);

                    AddTypeOfSeat();
                    break; // Exit the loop if the flight information is entered correctly.
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Flight ID must be a string.");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        private bool CheckFlight(string flightID)
        {
            return flights.All(flight => flight.FlightID != flightID);
        }

        public void Remove()
        {
            Console.WriteLine("Enter Flight ID to remove:");
            string flightIDToDelete = Console.ReadLine();

            Flight flightToRemove = flights.FirstOrDefault(flight => flight.FlightID == flightIDToDelete);

            if (flightToRemove != null)
            {
                flights.Remove(flightToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Flight removed successfully.");
                Console.ResetColor();

                // Remove the associated type of seat
                RemoveTypeOfSeat(flightIDToDelete);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Flight not found.");
                Console.ResetColor();
            }
        }

        public void AddTypeOfSeat()
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("Choose type of seat you want to add:");
                    Console.WriteLine("1. Business Class");
                    Console.WriteLine("2. Economy Class");
                    Console.WriteLine("3. Back");
                    int choose = int.Parse(Console.ReadLine());

                    if (choose == 1)
                    {
                        Console.WriteLine("Seat ID:");
                        businessClassflight.SeatID = Console.ReadLine();
                        Console.WriteLine("Cabin:");
                        businessClassflight.Cabin = Console.ReadLine();
                        flights.Add(businessClassflight);
                    }
                    else if (choose == 2)
                    {
                        Console.WriteLine("Seat ID:");
                        economyClassflight.SeatID = Console.ReadLine();
                        Console.WriteLine("Cabin:");
                        economyClassflight.Cabin = Console.ReadLine();
                        flights.Add(economyClassflight);
                    }
                    else if (choose == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Wrong input!");
                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Please enter a valid numeric choice.");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        public void RemoveTypeOfSeat(string flightID)
        {
            Console.WriteLine("Choose type of seat you want to remove:");
            Console.WriteLine("1. Business Class");
            Console.WriteLine("2. Economy Class");
            int choose = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter type of seat you want to remove:");
            string SeatIdToDelete = Console.ReadLine();

            Flight seatToRemove = null;

            if (choose == 1)
            {
                seatToRemove = flights.FirstOrDefault(flight => flight is BusinessClassflight && flight.SeatID == SeatIdToDelete);
            }
            else if (choose == 2)
            {
                seatToRemove = flights.FirstOrDefault(flight => flight is EconomyClassflight && flight.SeatID == SeatIdToDelete);
            }

            if (seatToRemove != null)
            {
                flights.Remove(seatToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Seat removed successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Seat not found.");
                Console.ResetColor();
            }
        }

        public void DisplayTypeOfSeat()
        {
            Console.WriteLine("Economy Class:");
            Console.WriteLine("--------------------");
            foreach (Flight flight in flights)
            {
                if (flight is EconomyClassflight)
                {
                    flight.displayInformation();
                    Console.WriteLine("--------------------");
                }
            }

            Console.WriteLine("Business Class:");
            Console.WriteLine("--------------------");
            foreach (Flight flight in flights)
            {
                if (flight is BusinessClassflight)
                {
                    flight.displayInformation();
                    Console.WriteLine("--------------------");
                }
            }
        }

        public Flight GetSeatByID(string Sid)
        {
            foreach (Flight seat in flights)
            {
                if (seat.SeatID == Sid)
                {
                    return seat;
                }
            }
            return null;
        }
        public Flight GetFlightByID(string Fid)
        {
            foreach (Flight flight in flights)
            {
                if (flight.FlightID == Fid)
                {
                    return flight;
                }
            }
            return null;
        }
    }
}
