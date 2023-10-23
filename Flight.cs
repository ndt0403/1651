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
        private string fromLocation;
        private string toLocation;
        private string seatID;
        private string cabin;

        public string FlightID
        {
            get { return flightID; }
            set { flightID = value; }
        }
        public string FromLocation
        {
            get { return fromLocation; }
            set { fromLocation = value; }
        }
        public string ToLocation
        {
            get { return toLocation; }
            set { toLocation = value; }
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

        public Flight(string flightID, string fromLocation, string toLocation, string seatID, string cabin)
        {
            // Parameterized constructor to initialize flight attributes.
            FlightID = flightID;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            SeatID = seatID;
            Cabin = cabin;
        }

        public virtual void displayInformation()
        {
            // Method to display flight information.
            Console.WriteLine("===================");
            Console.WriteLine("Flight information:");
            Console.WriteLine("Flight ID: " + FlightID);
            Console.WriteLine("From: " + FromLocation);
            Console.WriteLine("To: " + ToLocation);
            Console.WriteLine("Seat ID: " + SeatID);
            Console.WriteLine("Cabin: " + Cabin);
        }
    }
}
