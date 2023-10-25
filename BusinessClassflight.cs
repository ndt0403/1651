using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class BusinessClassflight : Flight
    {
        // The BusinessClassflight class is a subclass of the Flight class.

        // Default constructor for the BusinessClassflight class.
        public BusinessClassflight() { }

        // Parameterized constructor for the BusinessClassflight class.
        public BusinessClassflight(string flightID, string seatID, string fromLocation, string toLocation, string cabin) : base(flightID, fromLocation, toLocation, seatID, cabin)
        { }

        // Override the displayInformation method from the base class (Flight).
        public override void displayInformation()
        {
            // Display information specific to Business Class flight.
            Console.ForegroundColor = ConsoleColor.DarkRed; // Set text color
            Console.WriteLine("Business Class Information:");
            Console.ResetColor(); // Reset text color to the default
            Console.WriteLine("Seat ID: " + SeatID);
            Console.WriteLine("Cabin: " + Cabin);
            Console.WriteLine("--------------------");
        }
    }
}
