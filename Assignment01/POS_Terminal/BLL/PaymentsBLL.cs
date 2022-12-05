using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PaymentsBLL
    {
        public PaymentsDTO checkPayment(int saleId)
        {
            PaymentsDTO paymentDTO = new PaymentsDTO();
            PaymentsDAL paymentDAL = new PaymentsDAL();
            paymentDTO = paymentDAL.checkPayment(saleId);
            return paymentDTO;
        }

        public int addReceipt(ReceiptDTO receiptDTO)
        {
            PaymentsDAL paymentDAL = new PaymentsDAL();
            return paymentDAL.addReceipt(receiptDTO);
        }
    }
}
