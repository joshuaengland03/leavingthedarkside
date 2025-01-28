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






//        if (choice == "1")
//        {
//            Console.WriteLine("You chose to place an order. What kind of product?");
//            Console.WriteLine("Options: Electronics, Groceries, Clothing");
//            string productType = Console.ReadLine();

//            if (productType.ToLower() == "electronics")
//            {
//                Console.WriteLine("Order placed for Electronics!");
//            }
//            else if (productType.ToLower() == "groceries")
//            {
//                Console.WriteLine("Order placed for Groceries!");
//            }
//            else if (productType.ToLower() == "clothing")
//            {
//                Console.WriteLine("Order placed for Clothing!");
//            }
//            else
//            {
//                Console.WriteLine("Invalid product type.");
//            }
//        }
//        else if (choice == "2")
//        {
//            Console.WriteLine("You chose to cancel an order.");
//            Console.WriteLine("Enter the product type you want to cancel: Electronics, Groceries, Clothing");
//            string cancelType = Console.ReadLine();

//            if (cancelType.ToLower() == "electronics")
//            {
//                Console.WriteLine("Order for Electronics canceled.");
//            }
//            else if (cancelType.ToLower() == "groceries")
//            {
//                Console.WriteLine("Order for Groceries canceled.");
//            }
//            else if (cancelType.ToLower() == "clothing")
//            {
//                Console.WriteLine("Order for Clothing canceled.");
//            }
//            else
//            {
//                Console.WriteLine("Invalid product type.");
//            }
//        }
//        else if (choice == "3")
//        {
//            Console.WriteLine("You chose to track an order.");
//            Console.WriteLine("Enter the product type to track: Electronics, Groceries, Clothing");
//            string trackType = Console.ReadLine();

//            if (trackType.ToLower() == "electronics")
//            {
//                Console.WriteLine("Tracking information for Electronics.");
//            }
//            else if (trackType.ToLower() == "groceries")
//            {
//                Console.WriteLine("Tracking information for Groceries.");
//            }
//            else if (trackType.ToLower() == "clothing")
//            {
//                Console.WriteLine("Tracking information for Clothing.");
//            }
//            else
//            {
//                Console.WriteLine("Invalid product type.");
//            }
//        }
//        else if (choice == "4")
//        {
//            Console.WriteLine("Exiting the system. Goodbye!");
//        }
//        else
//        {
//            Console.WriteLine("Invalid option. Please restart the program.");
//        }
//    }
//}
