using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class PaymentsView
    {
        public static void Payment()
        {
            bool i = false;
            int saleId = 0;
            while (!i)
            {
                Console.Write("\n\tSale ID: ");
                Console.ForegroundColor = ConsoleColor.Red;
                i = int.TryParse(Console.ReadLine(), out saleId);
                Console.ForegroundColor = ConsoleColor.White;
                if (!i)
                    Console.WriteLine("\n\t\tPlease enter an integer!");
            }

            PaymentsDTO payment = new PaymentsDTO();
            PaymentsBLL paymentBLL = new PaymentsBLL();
            payment = paymentBLL.checkPayment(saleId);

            if(payment != null)
            {
                Console.Write($"\tCustomer Name: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{payment.CustomerName}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\tTotal Sales Amount: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{payment.TotalSalesAmount}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\tAmount Paid: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{payment.AmountPaid}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\tRemaining Amount: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{payment.RemainingAmount}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            bool p = false;
            int paid = 0;
            while (!p)
            {
                Console.Write("\tAmount To Be Paid: ");
                Console.ForegroundColor = ConsoleColor.Red;
                p = int.TryParse(Console.ReadLine(), out paid);
                Console.ForegroundColor = ConsoleColor.White;
                if (!p)
                    Console.WriteLine("\n\t\tPlease enter an integer!");
            }

            ReceiptDTO receiptDTO = new ReceiptDTO() { 
                ReceiptDateTime = DateTime.Now,
                OrderId = saleId,
                AmountToBePaid = paid
            };

            int count = paymentBLL.addReceipt(receiptDTO);
            if(count == 1)
            {
                Console.WriteLine("\n\t\tReceipt Added!");
            }

            Console.WriteLine(" Press any key to continue!");
            Console.ReadKey();
        }
    }
}
