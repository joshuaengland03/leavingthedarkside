using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using EnumTools;

class Program
{
    public static string product = "";
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Order Management System!");
        Console.WriteLine("Choose a number: ");
        Console.WriteLine("1. Place an order");
        Console.WriteLine("2. Cancel an order");
        Console.WriteLine("3. Track an order");
        Console.WriteLine("4. Exit");
        
        string choice = Console.ReadLine();

        if (Enum.TryParse(choice, out MenuOptions menuOption))
        {
            switch (menuOption)
            {
                case MenuOptions.PlaceAnOrder:
                    Console.WriteLine("You chose to place an order. What kind of product?");
                    ProductMenu();
                    Console.WriteLine("Order placed for " + product + "!");
                    break;
                case MenuOptions.CancelAnOrder:
                    Console.WriteLine("You chose to cancel an order.");
                    Console.WriteLine("Enter the product type you want to cancel:");
                    ProductMenu();
                    Console.WriteLine("Order for " + product + " canceled.");
                    break;
                case MenuOptions.TrackAnOrder:
                    Console.WriteLine("You chose to track an order.");
                    Console.WriteLine("Enter the product type to track:");
                    ProductMenu();
                    Console.WriteLine("Tracking information for " + product + ".");
                    break;
                case MenuOptions.Exit:
                    Console.WriteLine("Exiting the system. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please restart the program.");
                    break;
            }
        }
        else 
        {
            Console.WriteLine("Invalid option. Please restart the program.");
        }
        Console.WriteLine("How would you rate your experience from 1-10?");
        string input = Console.ReadLine();
        string thankYou = "";
        bool result = int.TryParse(input, out int rating);
        if (result && rating >= 1 && rating <=10)
            {
            thankYou = (rating > 7) ? "I'm glad you had a great experience! Have a nice day!" : "I'm sorry we could have done better. Have a nice day!";
            }
        else
        {
            Console.WriteLine("Error");
        }
        Console.WriteLine(thankYou);
    }












    static void ProductMenu()
    {
        Console.WriteLine("1. Electronics");
        Console.WriteLine("2. Groceries");
        Console.WriteLine("3. Clothing");

        string choice = Console.ReadLine();

        if (Enum.TryParse(choice, out ProductTypes productChoice))
        {
            switch (productChoice)
            {
                case ProductTypes.Electronics:
                    product = "Electronics";
                    break;
                case ProductTypes.Groceries:
                    product = "Groceries";
                    break;
                case ProductTypes.Clothing:
                    product = "Clothing";
                    break;
                default:
                    Console.WriteLine("Invalid option. Please restart the program.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid option. Please restart the program.");
        }
    }

}