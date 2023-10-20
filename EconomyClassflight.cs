using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class EconomyClassflight : Flight
    {
        public EconomyClassflight()
        {
            // Default constructor - It doesn't initialize any specific properties.
        }

        public EconomyClassflight(string flightID,string seatID, string cabin) : base(flightID, seatID, cabin)
        {
            // Parameterized constructor - Initializes the properties by calling the base class constructor.
        }

        public override void displayInformation()
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Set text color
            Console.WriteLine("Economy Class Information:");
            Console.ResetColor(); // Reset text color to the default
            Console.WriteLine("Seat ID: " + SeatID);
            Console.WriteLine("Cabin: " + Cabin);
            Console.WriteLine("--------------------");
        }
    }
}
