using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class SalesBLL
    {
        public bool addSales(SalesDTO salesDTO, List<SaleLineItemsDTO> saleLineItemsList)
        {
            SalesDAL salesDAL = new SalesDAL();
            return salesDAL.addSales(salesDTO, saleLineItemsList);
        } 
    }
}
