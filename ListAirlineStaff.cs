using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class ListAirlineStaff : InterfaceData
    {
        private List<AirlineStaff> airlineStaff;
        public ListAirlineStaff()
        {
            airlineStaff = new List<AirlineStaff>();
        }
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
            AirlineStaff staff = new AirlineStaff(Name, Phone, Country, Passport, StaffID);
            airlineStaff.Add(staff);
        }
        public void Remove()
        {
            Console.WriteLine("Input Id you want to remove");
            int id = int.Parse(Console.ReadLine());

            AirlineStaff staffToRemove = airlineStaff.Find(staff => staff.StaffID == id);

            if (staffToRemove != null)
            {
                airlineStaff.Remove(staffToRemove);
                Console.WriteLine("Staff removed successfully.");
            }
            else
            {
                Console.WriteLine("Staff not found.");
            }
        }
        public void DisplayStaff()
        {
            // Display information for each employee in the list.
            foreach (AirlineStaff staff in airlineStaff)
            {
                staff.PrintInformation();
                Console.WriteLine("--------------------");
            }
        }
    }
}
