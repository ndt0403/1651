using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class Person
    {
        private string name;
        private int phone;
        private string country;
        private string passport;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                name = value;
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Country cannot be null or empty.");
                }
                country = value;
            }
        }
        public string Passport
        {
            get { return passport; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Passport cannot be null or empty.");
                }
                passport = value;
            }
        }
        public int Phone
        {
            get { return phone; }
            set
            {
                // You can add validation for the phone number here.
                // For example, you can check if it's a valid phone number.
                if (value <= 0)
                {
                    throw new ArgumentException("Phone must be a positive integer.");
                }
                phone = value;
            }
        }


        public Person() { }

        public Person(string name, int phone, string country, string passport)
        {
            // Parameterized constructor to initialize person attributes.
            Name = name;
            Phone = phone;
            Country = country;
            Passport = passport;
        }

        public virtual void PrintInformation()
        {
            // Method to print person information.
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Phone: " + Phone);
            Console.WriteLine("Country: " + Country);
            Console.WriteLine("Passport: " + Passport);
        }
    }
}
