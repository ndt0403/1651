using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class Customer : Person
    {
        private int age;  // Private field to store the customer's age.

        public Customer(string name, int phone, string country, string passport,  int age) : base(name, phone, country, passport)
        {
            Age = age;
        }
        // Default constructor for the "Customer" class.
        public Customer() { }

        // Property to get and set the customer's age.
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative.");
                }
                age = value;
            }
        }

        // Parameterized constructor for the "Customer" class.
        // It initializes the customer's name, phone, country, passport, and age.
        

        // Method to enter customer details interactively.
        public void EnterCustomer()
        {
            Console.WriteLine("Enter customer details:");
            Console.Write("Name: ");
            Name = Console.ReadLine();  // Set the customer's name.
            Console.Write("Age: ");
            Age = int.Parse(Console.ReadLine());  // Set the customer's age.
            Console.Write("Phone: ");
            Phone = int.Parse(Console.ReadLine());  // Set the customer's age.
            Console.Write("Country: ");
            Country = Console.ReadLine();  // Set the customer's country.
            Console.Write("Passport: ");
            Passport = Console.ReadLine();  // Set the customer's passport.
        }

        // Override the base class's "PrintInformation" method to include age information.
        public override void PrintInformation()
        {
            base.PrintInformation();  // Call the base class's PrintInformation method.
            Console.WriteLine("Age:" + Age);  // Print the customer's age.
        }
    }
}
