using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BLL;
using System.Runtime.ConstrainedExecution;

namespace PL
{
    public class ItemsView
    {
        public static void ItemsMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t POS Terminal \n\n");
            Console.WriteLine("\tItems Menu\n");
            Console.WriteLine("\t 1 - Add New Item");
            Console.WriteLine("\t 2 - Update Item Details");
            Console.WriteLine("\t 3 - Find Items");
            Console.WriteLine("\t 4 - Remove Existing Item");
            Console.WriteLine("\t 5 - Back To Main Menu");
            Console.Write("\n Press 1 to 5 to select an option: ");
            int input = 0;
            bool inp = int.TryParse(Console.ReadLine(), out input);

            if(input == 1)
            {
                ItemsView.AddItem();
            }
            else if(input == 2)
            {
                ItemsView.UpdateItem();
            }
            else if(input == 3)
            {
                ItemsView.findItem();
            }
            else if(input == 4)
            {
                ItemsView.deleteItem();
            }
            else if(input == 5)
            {
                return;
            }
            ItemsView.ItemsMenu();
        }

        // Add Item
        public static void AddItem()
        {
            Console.Write("\n\tEnter Item Description: ");
            string description = Console.ReadLine();
            while(description.Length < 1) {
                Console.WriteLine("\n\t\tPlease enter some description");
                Console.Write("\n\tEnter Item Description: ");
                description = Console.ReadLine();
            }

            bool p = false;
            int price = 0;
            while (!p)
            {
                Console.Write("\tEnter Item Price: ");
                p = int.TryParse(Console.ReadLine(), out price);
                if(!p)
                    Console.WriteLine("\n\t\tPlease enter an integer");
            }
            bool q = false;
            int quantity = 0;
            while (!q)
            {
                Console.Write("\tEnter Item Quantity: ");
                q = int.TryParse(Console.ReadLine(), out quantity);
                if(!q)
                    Console.WriteLine("\n\t\tPlease enter an integer");
            }

            Console.Write("Do you want to add Item? (Press Y for yes OR N for no): ");

            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                ItemsDTO itemDTO = new ItemsDTO
                {
                    Description = description,
                    Price = price,
                    Quantity = quantity,
                };

                ItemsBLL itemBll = new ItemsBLL();
                int count = itemBll.AddItem(itemDTO);
                if(count == 1)
                    Console.WriteLine("\n\tItem Information Successfully Saved!");
            }
            else
            {
                Console.WriteLine("\n\t\tInformation was not added!");
            }
            Console.WriteLine(" Press any key to continue!");
            Console.ReadKey();
        }

        // Update Item
        public static void UpdateItem()
        {
            int itemId = 0;
            bool inp = false;
            while (!inp)
            {
                Console.Write("\tEnter Item Id: ");
                inp = int.TryParse(Console.ReadLine(), out itemId);
                if (!inp)
                    Console.WriteLine("\n\t\tPlease enter an integer");
            }

            ItemsDTO itemDto = new ItemsDTO();
            ItemsBLL itemBll = new ItemsBLL();
            itemDto = itemBll.checkItem(itemId);

            // If record exist
            if(itemDto != null)
            {
                Console.WriteLine($"\tDescription: {itemDto.Description}");
                Console.WriteLine($"\tPrice: {itemDto.Price}");
                Console.WriteLine($"\tQuantity: {itemDto.Quantity}");
                Console.WriteLine($"\tCreation Date: {itemDto.CreationDate}");

                // Update Changes in record
                itemDto.Id = itemId;
                Console.WriteLine("\n\tInput for Changing");
                Console.Write("\n\tEnter Item Description: ");
                string description = Console.ReadLine();
                
                Console.Write("\tEnter Item Price: ");
                int price;
                bool p = int.TryParse(Console.ReadLine(), out price);

                Console.Write("\tEnter Item Quantity: ");
                int quantity;
                bool q = int.TryParse(Console.ReadLine(), out quantity);
                if (description.Length > 0)
                    itemDto.Description = description;
                if (p)
                    itemDto.Price = Convert.ToInt32(price);
                if (q)
                    itemDto.Quantity = Convert.ToInt32(quantity);

                Console.Write("Do you want to update Item? (Press Y for yes OR N for no): ");

                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    int count = itemBll.updateItem(itemDto);
                    if (count == 1)
                        Console.WriteLine("\n\tItem Information Successfully Updated!");
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

        // Find Item
        public static void findItem()
        {
            int itemId = 0;
            Console.Write("\tItem ID: ");
            bool id = int.TryParse(Console.ReadLine(), out itemId);
            Console.Write("\tDescription: ");
            string description = Console.ReadLine();
            Console.Write("\tPrice: ");
            int price;
            bool p = int.TryParse(Console.ReadLine(), out price);
            Console.Write("\tQuantity: ");
            int quantity;
            bool q = int.TryParse(Console.ReadLine(), out quantity);
            Console.Write("\tCreation Date: ");
            DateTime? creationDateTime = null;
            string dateTime = Console.ReadLine();
            bool d = false;
            if (dateTime.Length == 22)
            {
                creationDateTime = Convert.ToDateTime(dateTime);
                d = true;
            }

            if (id || description.Length > 0 || p || q || d)
            {

                ItemsDTO itemDTO = new ItemsDTO
                {
                    Id = itemId,
                    Description = description,
                    Price = price,
                    Quantity = quantity,
                    CreationDate = creationDateTime
                };

                List<ItemsDTO> items = new List<ItemsDTO>();
                ItemsBLL itemBll = new ItemsBLL();
                items = itemBll.findItems(itemDTO);

                if(items != null)
                {
                    Console.WriteLine(" ---------------------------------------------------------------------------------");
                    Console.WriteLine("\tItem ID\t\tDescription\t\t\tPrice\t\tQuantity");
                    Console.WriteLine(" ---------------------------------------------------------------------------------");
                    foreach (ItemsDTO item in items)
                    {
                        Console.WriteLine($"\t{item.Id}\t\t{item.Description}\t\t\t\t{item.Price}\t\t{item.Quantity}");
                    }
                    Console.WriteLine(" ---------------------------------------------------------------------------------");
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

        // Delete Item
        public static void deleteItem()
        {
            bool id = false;
            int itemId = 0;
            while (!id)
            {
                Console.Write("\tEnter Item ID: ");
                id = int.TryParse(Console.ReadLine(), out itemId);
                if (!id)
                    Console.WriteLine("\n\t\tPlease enter an integer");
            }
            ItemsBLL itemBll = new ItemsBLL();
            int count = itemBll.deleteItem(itemId);
            if (count == 1)
                Console.WriteLine("\n\tItem deleted Successfully!");
            else
                Console.WriteLine("\n\tItem is in sale so it can't be deleted!");
            Console.WriteLine(" Press any key to continue!");
            Console.ReadKey();
        }
    }
}
