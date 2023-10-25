using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class AirlineStaff : Person
    {
        private int staffId;  // Private field to store the employee's ID.

        // Default constructor for the "Employee" class.
        public AirlineStaff() { }

        // Parameterized constructor for the "Employee" class.
        // It initializes the employee's name, phone, email, and employee ID.
        public AirlineStaff(string name, int phone, string country, string passport,  int staffId) : base(name, phone, country, passport)
        {
            StaffID = staffId;
        }

        // Property to get and set the employee's ID.
        public int StaffID
        {
            get { return staffId; }
            set { staffId = value; }
        }

        // Override the base class's "PrintInfo" method to include employee information.
        public override void PrintInformation()
        {
            Console.WriteLine("Employee information:");
            Console.WriteLine("Id:" + StaffID);  // Print the employee's ID.
            base.PrintInformation();  // Call the base class's PrintInfo method to print name, phone, and email.
        }
    }
}
