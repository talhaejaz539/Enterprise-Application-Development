using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using DTO;
using BLL;

namespace PL
{
    public class SalesView
    {
        public static int salesId = 1;

        public void Sales()
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"\n\tSales ID: {salesId}");
            Console.WriteLine($"\n\tSales Date: {dateTime}");

            bool c = false;
            int customerId = 0;
            while (!c)
            {
                Console.Write("\n\tCustomer ID: ");
                c = int.TryParse(Console.ReadLine(), out customerId);
                if (!c)
                    Console.WriteLine("\n\t\tPlease enter an integer!");
            }

            CustomersDTO customersDTO = new CustomersDTO();
            CustomersBLL customersBLL = new CustomersBLL();
            customersDTO = customersBLL.checkCustomer(customerId);

            if (customersDTO == null)
            {
                Console.WriteLine("\n\t\t\tNo data exist against given customer id!");
                Console.ReadKey();
                return;
            }

            List<SaleLineItemsDTO> saleLineItemsList = new List<SaleLineItemsDTO>();
            SalesDTO salesDTO = new SalesDTO();
            salesDTO.OrderId = salesId;
            salesDTO.SaleDateTime = dateTime;
            salesDTO.CustomerId = customersDTO.Id;
            salesDTO.CustomerName = customersDTO.Name;
            salesDTO.Status = "Unpaid";

            int totalSale = 0;
            SalesView sales = new SalesView();

            int input = 1;
            do
            {
                if (input == 1)
                {
                    totalSale += sales.AddSale(customersDTO, saleLineItemsList);
                }
                else if (input == 3)
                {
                    sales.RemoveItem(saleLineItemsList);
                }
                else if (input == 4)
                {
                    return;
                }

                Console.WriteLine("\n\n\tPress 1 to Enter New Item");
                Console.WriteLine("\tPress 2 to End Sale");
                Console.WriteLine("\tPress 3 to Remove an existing Item from the current sale");
                Console.WriteLine("\tPress 4 to Cancel Sale");

                Console.Write("\n Press 1 to 4 to select an option: ");
                bool inp = int.TryParse(Console.ReadLine(), out input);

                if (input == 2)
                {
                    salesDTO.TotalSales = totalSale;
                    SalesBLL salesBLL = new SalesBLL();
                    bool flag = salesBLL.addSales(salesDTO, saleLineItemsList);
                    if(flag)
                        sales.printSale(salesDTO, saleLineItemsList, totalSale);

                    salesId++;
                    Console.WriteLine(" Press any key to continue!");
                    Console.ReadKey();
                }

            } while (input != 2);
        }

        // Add Sales
        public int AddSale(CustomersDTO customersDTO, List<SaleLineItemsDTO> saleLineItemsList)
        {
            int totalSale = 0;
            bool i = false;
            int itemId = 0;
            while (!i)
            {
                Console.Write("\n\tItem ID: ");
                Console.ForegroundColor = ConsoleColor.Red;
                i = int.TryParse(Console.ReadLine(), out itemId);
                Console.ForegroundColor = ConsoleColor.White;
                if (!i)
                    Console.WriteLine("\n\t\tPlease enter an integer!");
            }

            ItemsDTO itemDTO = new ItemsDTO();
            ItemsBLL itemsBLL = new ItemsBLL();
            itemDTO = itemsBLL.checkItem(itemId);

            if (itemDTO == null)
            {
                Console.WriteLine("\n\t\t\tNo data exist against given item id!");
                Console.ReadKey();
                totalSale += 1;
                return -1;
            }

            Console.Write($"\tDescription: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(itemDTO.Description);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\tPrice: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Rs. {itemDTO.Price}");
            Console.ForegroundColor = ConsoleColor.White;

            bool q = false;
            int quantity = 0;
            while (!q)
            {
                Console.Write("\tQuantity: ");
                Console.ForegroundColor = ConsoleColor.Red;
                q = int.TryParse(Console.ReadLine(), out quantity);
                Console.ForegroundColor = ConsoleColor.White;
                if (!q)
                    Console.WriteLine("\n\t\tPlease enter an integer!");
            }

            int subTotal = itemDTO.Price * quantity;
            Console.Write("\tSub-Total: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Rs. {subTotal}");
            Console.ForegroundColor = ConsoleColor.White;

            SaleLineItemsDTO saleLineItemsDTO = new SaleLineItemsDTO()
            {
                ItemId = itemDTO.Id,
                Description = itemDTO.Description,
                Quantity = quantity,
                Amount = subTotal
            };

            totalSale = subTotal;
            if (totalSale <= customersDTO.SalesLimit)
            {
                saleLineItemsList.Add(saleLineItemsDTO);
            }
            else
            {
                Console.WriteLine("\n\t\tDaily Limit Exceeded!");
                totalSale = 0;
            }
            return totalSale;
        }

        // Print Sales
        public void printSale(SalesDTO salesDTO, List<SaleLineItemsDTO> saleLineItemsList, int totalSale)
        {
            Console.WriteLine($"\tSales ID: {salesDTO.OrderId}                                            Customer ID: {salesDTO.CustomerId}");
            Console.WriteLine($"\tSales Date: {salesDTO.SaleDateTime}                     Name: {salesDTO.CustomerName}");
            Console.WriteLine(" ---------------------------------------------------------------------------------");
            Console.WriteLine("\tItem ID\t\tDescription\t\t\tQuantity\tAmount");
            Console.WriteLine(" ---------------------------------------------------------------------------------");
            foreach (SaleLineItemsDTO item in saleLineItemsList)
            {
                Console.WriteLine($"\t{item.ItemId}\t\t{item.Description}\t\t\t\t{item.Quantity}\t\t{item.Amount}");
            }
            Console.WriteLine(" ---------------------------------------------------------------------------------");
            Console.WriteLine($"                                                          Total Sales: Rs. {totalSale}");
            Console.WriteLine(" ---------------------------------------------------------------------------------");
        }

        //Remove Item From Sale
        public void RemoveItem(List<SaleLineItemsDTO> saleLineItemsList)
        {
            bool q = false;
            int number = 0;
            while (!q)
            {
                Console.Write("\n\tEnter Number of Item in List: ");
                Console.ForegroundColor = ConsoleColor.Red;
                q = int.TryParse(Console.ReadLine(), out number);
                Console.ForegroundColor = ConsoleColor.White;
                if (!q)
                    Console.WriteLine("\n\t\tPlease enter an integer!");
            }
            try {
                saleLineItemsList.RemoveAt(number);
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n\tItem doesnot exist in List!");
            }
        }
    }
}
