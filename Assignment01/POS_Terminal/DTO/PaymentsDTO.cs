using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PaymentsDTO
    {
        public int SaleId { get; set; }
        public string CustomerName { get; set; }
        public int TotalSalesAmount { get; set; }
        public int AmountPaid { get; set; }
        public int RemainingAmount { get; set; }
    }
}
