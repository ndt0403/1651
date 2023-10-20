using ASM2_1651_NguyenDinhTam_GCD210186;
using System;

class Program
{
    static Dictionary<string, string> usernamepassword = new Dictionary<string, string>
    {
        { "dinhtam", "12345" }
    };
    private static bool loggedIn = false;
    static void Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Set text color to yellow
            Console.WriteLine("===========================");
            Console.WriteLine("|| Welcome to my Airline ||");
            Console.WriteLine("===========================");
            Console.ResetColor(); // Reset text color to the default
            Console.WriteLine(("1.").PadLeft(10) + ("Login").PadLeft(6));
            Console.WriteLine(("2.").PadLeft(10) + ("Exit").PadLeft(5));
            Console.WriteLine("Enter your choice:");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Cyan; // Set text color to green
                    Console.WriteLine("Exiting the program. Goodbye!");
                    Console.ResetColor(); // Reset text color to the default
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed; // Set text color to green
                    Console.WriteLine("Invalid choice. Please select a valid option (1 or 2)");
                    Console.ResetColor(); // Reset text color to the default
                    break;
            }
        }
    }
    static void Login()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (usernamepassword.TryGetValue(username, out string Passw) && password == Passw)
        {
            Console.ForegroundColor = ConsoleColor.Green; // Set text color to green
            Console.WriteLine("Login successful!");
            Console.ResetColor(); // Reset text color to the default
            Admin admin = new Admin();
            admin.DisplayMenu();
            loggedIn = true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set text color to green
            Console.WriteLine("Login failed! Incorrect username or password.");
            Console.ResetColor(); // Reset text color to the default
        }
    }

    public void SetLoggedIn(bool value)
    {
        loggedIn = value;
    }
}