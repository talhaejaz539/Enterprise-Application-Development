using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SalesDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime SaleDateTime { get; set; }
        public int TotalSales { get; set; }
    }
}
