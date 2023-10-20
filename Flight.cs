using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class Flight
    {
        private string flightID;
        private string seatID;
        private string cabin;

        public string FlightID
        {
            get { return flightID; }
            set { flightID = value; }
        }
        public string SeatID
        {
            get { return seatID; }
            set { seatID = value; }
        }

        public string Cabin
        {
            get { return cabin; }
            set { cabin = value; }
        }

        public Flight() { }

        public Flight(string flightID, string seatID, string cabin)
        {
            // Parameterized constructor to initialize flight attributes.
            FlightID = flightID;
            SeatID = seatID;
            Cabin = cabin;
        }

        public virtual void displayInformation()
        {
            // Method to display flight information.
            Console.WriteLine("===================");
            Console.WriteLine("Flight information:");
            Console.WriteLine("Flight ID: " + FlightID);
        }
    }
}
