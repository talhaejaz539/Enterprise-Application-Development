using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReceiptDTO
    {
        public DateTime ReceiptDateTime { get; set; }
        public int OrderId { get; set; }
        public int AmountToBePaid { get; set; }
    }
}
