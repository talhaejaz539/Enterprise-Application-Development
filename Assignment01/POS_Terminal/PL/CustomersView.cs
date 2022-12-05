using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BLL;

namespace PL
{
    public class CustomersView
    {
        public static void CustomersMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t POS Terminal \n\n");
            Console.WriteLine("\tCustomers Menu\n");
            Console.WriteLine("\t 1 - Add New Customer");
            Console.WriteLine("\t 2 - Update Customer Details");
            Console.WriteLine("\t 3 - Find Customer");
            Console.WriteLine("\t 4 - Remove Existing Customer");
            Console.WriteLine("\t 5 - Back To Main Menu");
            Console.Write("\n Press 1 to 5 to select an option: ");
            int input = 0;
            bool inp = int.TryParse(Console.ReadLine(), out input);
            if(input == 1)
            {
                CustomersView.AddCustomer();
            }
            else if(input == 2)
            {
                CustomersView.UpdateCustomer();
            }
            else if (input == 3)
            {
                CustomersView.findCustomer();
            }
            else if (input == 4)
            {
                CustomersView.deleteCustomer();
            }
            else if (input == 5)
            {
                return;
            }
            CustomersView.CustomersMenu();
        }

        // Add Customer
        public static void AddCustomer()
        {
            Console.Write("\n\tEnter Customer Name: ");
            string name = Console.ReadLine();
            while(name.Length < 1)
            {
                Console.WriteLine("\n\t\tPlease enter customer name!");
                Console.Write("\n\tEnter Customer Name: ");
                name = Console.ReadLine();
            }

            Console.Write("\n\tEnter Customer Address: ");
            string address = Console.ReadLine();
            while(address.Length < 1)
            {
                Console.WriteLine("\n\t\tPlease enter customer address!");
                Console.Write("\n\tEnter Customer Address: ");
                address = Console.ReadLine();
            }

            Console.Write("\n\tEnter Customer Phone: ");
            string phone = Console.ReadLine();
            while (phone.Length < 1)
            {
                Console.WriteLine("\n\t\tPlease enter customer phone!");
                Console.Write("\n\tEnter Customer Phone: ");
                phone = Console.ReadLine();
            }

            Console.Write("\n\tEnter Customer Email: ");
            string email = Console.ReadLine();
            while(email.Length < 1)
            {
                Console.WriteLine("\n\tPlease enter customer email!");
                Console.Write("\n\tEnter Customer Email: ");
                email = Console.ReadLine();
            }

            bool s = false;
            int saleLimit = 0;
            while (!s)
            {
                Console.Write("\n\tEnter Customer Sales Limit: ");
                s = int.TryParse(Console.ReadLine(), out saleLimit);
                if (!s)
                    Console.WriteLine("\n\t\tPlease enter an integer!");
            }

            Console.Write("\nDo you want to add Item? (Press Y for yes OR N for no): ");

            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                CustomersDTO customerDTO = new CustomersDTO
                {
                    Name = name,
                    Address = address,
                    Phone = phone,
                    Email = email,
                    SalesLimit = saleLimit
                };

                CustomersBLL customerBLL = new CustomersBLL();
                int count = customerBLL.AddCustomer(customerDTO);
                if(count == 1)
                    Console.WriteLine("\n\tCustomer Information Successfully Saved!");
            }
            else
            {
                Console.WriteLine("\n\t\tInformation was not added!");
            }
            Console.WriteLine(" Press any key to continue!");
            Console.ReadKey();
        }

        // Update Customer
        public static void UpdateCustomer()
        {
            int customerId = 0;
            bool inp = false;
            while (!inp)
            {
                Console.Write("\tEnter Customer Id: ");
                inp = int.TryParse(Console.ReadLine(), out customerId);
                if (!inp)
                    Console.WriteLine("\n\t\tPlease enter an integer");
            }

            CustomersDTO customerDTO = new CustomersDTO();
            CustomersBLL customerBLL = new CustomersBLL();
            customerDTO = customerBLL.checkCustomer(customerId);

            // If record exist
            if(customerDTO != null) {
                Console.WriteLine($"\tName: {customerDTO.Name}");
                Console.WriteLine($"\tAddress: {customerDTO.Address}");
                Console.WriteLine($"\tPhone: {customerDTO.Phone}");
                Console.WriteLine($"\tEmail: {customerDTO.Email}");
                Console.WriteLine($"\tSales Limit: {customerDTO.SalesLimit}");

                //Update changes in record
                customerDTO.Id = customerId;
                Console.WriteLine("\n\tInput for Changing");
                Console.Write("\n\tEnter Customer Name: ");
                string name = Console.ReadLine();

                Console.Write("\n\tEnter Customer Address: ");
                string address = Console.ReadLine();

                Console.Write("\n\tEnter Customer Phone: ");
                string phone = Console.ReadLine();

                Console.Write("\n\tEnter Customer Email: ");
                string email = Console.ReadLine();

                Console.Write("\n\tEnter Customer Sales Limit: ");
                int saleLimit;
                bool s = int.TryParse(Console.ReadLine(), out saleLimit);

                if(name.Length > 0) 
                    customerDTO.Name = name;
                if(address.Length > 0)
                    customerDTO.Address = address;
                if(phone.Length > 0)
                    customerDTO.Phone = phone;
                if(email.Length > 0)
                    customerDTO.Email = email;
                if (s)
                    customerDTO.SalesLimit = Convert.ToInt32(saleLimit);

                Console.Write("Do you want to update Item? (Press Y for yes OR N for no): ");

                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    int count = customerBLL.updateCustomer(customerDTO);
                    if (count == 1)
                        Console.WriteLine("\n\tCustomer Information Successfully Updated!");
                }
                else
                {
                    Console.WriteLine("\n\t\tInformation was not updated!");
                }
            }
            else
            {
                Console.WriteLine("\tNo record matches with the given Input!");
            }

            Console.WriteLine(" Press any key to continue!");
            Console.ReadKey();
        }

        // Find Customer
        public static void findCustomer()
        {
            int customerId = 0;
            Console.Write("\tCustomer ID: ");
            bool id = int.TryParse(Console.ReadLine(), out customerId);

            Console.Write("\tName: ");
            string name = Console.ReadLine();

            Console.Write("\tEmail: ");
            string email = Console.ReadLine();

            Console.Write("\tPhone: ");
            string phone = Console.ReadLine();

            Console.Write("\tSales Limit: ");
            int saleLimit;
            bool s = int.TryParse(Console.ReadLine(), out saleLimit);

            if(id || name.Length > 0 || email.Length > 0 || phone.Length > 0 || s)
            {
                CustomersDTO customerDTO = new CustomersDTO {
                    Id = customerId,
                    Name = name,
                    Email = email,
                    Phone = phone,
                    SalesLimit = saleLimit
                };

                List<CustomersDTO> customers = new List<CustomersDTO>();
                CustomersBLL customerBLL = new CustomersBLL();
                customers = customerBLL.findCustomers(customerDTO);

                if(customers != null)
                {
                    Console.WriteLine(" --------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\tCustomer ID\t\tName\t\tEmail\t\t\tPhone\t\tSales Limit");
                    Console.WriteLine(" --------------------------------------------------------------------------------------------------------");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"\t{customer.Id}\t\t\t{customer.Name}\t\t{customer.Email}\t{customer.Phone}" +
                            $"\t{customer.SalesLimit}");
                    }
                    Console.WriteLine(" --------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("\n\t\tNo Data matches with given input!");
                }
                Console.WriteLine(" Press any key to continue!");
                Console.ReadKey();
            }
            else
            {
                return;
            }
        }

        // Delete Customer
        public static void deleteCustomer()
        {
            bool id = false;
            int customerId = 0;
            while (!id)
            {
                Console.Write("\tEnter Customer ID: ");
                id = int.TryParse(Console.ReadLine(), out customerId);
                if (!id)
                    Console.WriteLine("\n\t\tPlease enter an integer");
            }

            CustomersBLL customerBLL = new CustomersBLL();
            int count = customerBLL.deleteCustomer(customerId);
            if (count == 1)
                Console.WriteLine("\n\tCustomer deleted Successfully!");
            else
                Console.WriteLine("\n\t\tCustomer id is in sales!");

            Console.WriteLine(" Press any key to continue!");
            Console.ReadKey();
        }
    }
}
