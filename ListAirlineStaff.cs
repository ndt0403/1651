using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;  // Import necessary namespaces.
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class ListAirlineStaff : InterfaceData
    {
        private List<AirlineStaff> airlineStaff;  // Private field to store a list of airline staff members.

        public ListAirlineStaff()
        {
            airlineStaff = new List<AirlineStaff>();  // Initialize the list when the class is instantiated.
        }

        // Method to add a new airline staff member.
        public void Add()
        {
            Console.WriteLine("Enter Staff Details:");
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("Phone: ");
            int Phone = int.Parse(Console.ReadLine());
            Console.Write("Country: ");
            string Country = Console.ReadLine();
            Console.Write("Passport: ");
            string Passport = Console.ReadLine();
            Console.WriteLine("ID:");
            int StaffID = int.Parse(Console.ReadLine());

            // Create an AirlineStaff object and add it to the list.
            AirlineStaff staff = new AirlineStaff(Name, Phone, Country, Passport, StaffID);
            airlineStaff.Add(staff);
        }

        // Method to remove an airline staff member based on ID.
        public void Remove()
        {
            Console.WriteLine("Input Id you want to remove");
            int id = int.Parse(Console.ReadLine());

            // Find the staff member with the specified ID.
            AirlineStaff staffToRemove = airlineStaff.Find(staff => staff.StaffID == id);

            if (staffToRemove != null)
            {
                // Remove the staff member if found.
                airlineStaff.Remove(staffToRemove);
                Console.WriteLine("Staff removed successfully.");
            }
            else
            {
                Console.WriteLine("Staff not found.");
            }
        }

        // Method to display information for all airline staff members.
        public void DisplayStaff()
        {
            // Display information for each employee in the list.
            foreach (AirlineStaff staff in airlineStaff)
            {
                staff.PrintInformation();  // Call the PrintInformation method of the AirlineStaff class.
                Console.WriteLine("--------------------");
            }
        }
    }
}
