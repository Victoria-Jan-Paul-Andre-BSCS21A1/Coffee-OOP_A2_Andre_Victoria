using System;
using System.Collections.Generic;

namespace Coffee_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> menu = new Dictionary<string, double>(); //store itemName and itemPrice
            List<string> productOrder = new List<string>(); //store the orders by the user

            while (true)
            {
                try
                {
                    Print("Welcome to the Coffee Shop!");
                    Print("\n1. Add Menu Item\r\n2. View Menu\r\n3. Place Order\r\n4. View Order\r\n5. Calculate Total\r\n6. Exit");

                    Console.Write("\nSelect an option: ");
                    int userChoice = Convert.ToInt32(Console.ReadLine());

                    switch (userChoice)
                    {
                        case 1:
                            AddMenuItem(menu);
                            break;                                      
                        case 2:
                            ViewMenu(menu);
                            break;
                        case 3:
                            PlaceOrder(menu, productOrder);
                            break;
                        case 4:
                            ViewOrder(menu, productOrder);
                            break;
                        case 5:
                            CalculateTotal(menu, productOrder);
                            break;
                        case 6:
                            Print("Thank you for coming!");
                            return;
                        default:
                            Print("\nTry again.\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Print($"An error occurred: {ex.Message}"); //displays any error possible, indicating the detailed error
                }
            }
        }

        static void Print(string output)
        {
            Console.WriteLine(output);
        }


        static void AddMenuItem(Dictionary<string, double> menu)
        {
            Console.Write("Enter item name: ");
            var itemName = Console.ReadLine();
            Console.Write("Enter item price: ");
            var itemPrice = Convert.ToDouble(Console.ReadLine());

            menu.Add(itemName, itemPrice);
            Print("\nItem Added Successfully!");
        }

        static void ViewMenu(Dictionary<string, double> menu)
        {
            if (menu.Count == 0) //Checks the dicitionary if there are elements using count method
            {
                Print("The menu is empty.");
            }
            else
            {
                Print("\nMenu:");
                int productNumber = 1; //for product number
                foreach (var item in menu)
                {
                    Print($"{productNumber}. {item.Key} - ${item.Value:F2}"); // displays alltogether (product number, itemName, itemPrice)
                    productNumber++;
                }
            }
        }

        static void PlaceOrder(Dictionary<string, double> menu, List<string> productOrder)
        {
            if (menu.Count == 0)
            {
                Print("The menu is empty. Please add items to the menu first.");
                return;
            }

            Print("\nMenu:");
            int count = 1;
            List<string> fValue = new List<string>(menu.Keys); //contains all the itemnames in the dictionary
            foreach (var item in menu)
            {
                Print($"{count}. {item.Key} - ${item.Value:F2}");
                count++;
            }

            Console.Write("Enter the item number to order: ");
            int itemNumber = Convert.ToInt32(Console.ReadLine());

            if (itemNumber > 0 && itemNumber <= menu.Count)
            {
                string orderedItem = fValue[itemNumber - 1]; // subtracts 1 to make it 0 for the first value and so on
                productOrder.Add(orderedItem); // adds the item in the list
                Print("Item added to order!\n");
            }
            else
            {
                Print("No corresponding item number in the menu. Try again!\n");
            }
        }

        static void ViewOrder(Dictionary<string, double> menu, List<string> productOrder)
        {
            if (productOrder.Count == 0)
            {
                Print("Your order is empty.");
            }
            else
            {
                Print("Your Order:");
                foreach (var item in productOrder) //iterates over each element in the list
                {
                    double itemPrice = menu[item]; // looks up the price in the list produtOrder
                    Print($"{item} - ${itemPrice:F2}");
                }
            }
        }

        static void CalculateTotal(Dictionary<string, double> menu, List<string> productOrder)
        {
            if (productOrder.Count <= 0)
            {
                Print("There are no inputted orders, try again!");
            }
            else
            {
                double totalPrice = 0;
                foreach (var item in productOrder) //gets all the items in the productOrder list
                {
                    totalPrice += menu[item]; //retrieves the price of the current item from the dictionary using the item name
                }
                Print($"Total Amount Payable by admin: ${totalPrice:F2}");
            }
        }
    }
}