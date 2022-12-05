using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PaymentsDAL : BaseDAL
    {
        public PaymentsDTO checkPayment(int saleId)
        {
            PaymentsDTO payment = new PaymentsDTO();
            payment = PaymentCheck(saleId);
            return payment;
        }

        public int addReceipt(ReceiptDTO receiptDTO)
        {
            return ReceiptMake(receiptDTO);
        }
    }
}
