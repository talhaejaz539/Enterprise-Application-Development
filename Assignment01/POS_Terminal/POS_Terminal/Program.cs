// See https://aka.ms/new-console-template for more information
using PL;
using System;

int input = 0;
do
{
    mainMenu();

    Console.Write("\n Press 1 to 5 to select an option: ");
    bool inp = int.TryParse(Console.ReadLine(), out input);

    if (input == 1)
    {
        ItemsView.ItemsMenu();
    }
    else if (input == 2)
    {
        CustomersView.CustomersMenu();
    }
    else if (input == 3)
    {
        SalesView sales = new SalesView();
        sales.Sales();
    }
    else if (input == 4)
    {
        PaymentsView.Payment();
    }
} while (input != 5);


// Main Menu Function
void mainMenu()
{
    Console.Clear();
    Console.WriteLine("\n\n\t\t\t\t POS Terminal \n\n");
    Console.WriteLine("\tMain Menu\n");
    Console.WriteLine("\t 1 - Manage Items");
    Console.WriteLine("\t 2 - Manage Customers");
    Console.WriteLine("\t 3 - Make New Sale");
    Console.WriteLine("\t 4 - Make Payment");
    Console.WriteLine("\t 5 - Exit");
}
