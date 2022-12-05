using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class CustomersBLL
    {
        public int AddCustomer(CustomersDTO customerDTO)
        {
            customerDTO.AmountPayable = 0;
            CustomersDAL customerDAL = new CustomersDAL();
            return customerDAL.AddCustomer(customerDTO);
        }

        public CustomersDTO checkCustomer(int customerId)
        {
            CustomersDTO customerDTO = new CustomersDTO();
            CustomersDAL customerDAL = new CustomersDAL();
            customerDTO = customerDAL.checkCustomer(customerId);
            return customerDTO;
        }

        public int updateCustomer(CustomersDTO customerDTO)
        {
            CustomersDAL customerDAL = new CustomersDAL();
            return customerDAL.updateCustomer(customerDTO);
        }

        public List<CustomersDTO> findCustomers(CustomersDTO customerDTO)
        {
            List<CustomersDTO> list = new List<CustomersDTO>();
            CustomersDAL customerDAL = new CustomersDAL();
            list = customerDAL.findCustomers(customerDTO);
            return list;
        }

        public int deleteCustomer(int customerId)
        {
            CustomersDAL customerDAL = new CustomersDAL();
            return customerDAL.deleteCustomer(customerId);
        }
    }
}
