using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SalesDAL : BaseDAL
    {
        public bool addSales(SalesDTO salesDTO, List<SaleLineItemsDTO> saleLineItemsList)
        {
            return salesAdd(salesDTO, saleLineItemsList);
        }
    }
}
