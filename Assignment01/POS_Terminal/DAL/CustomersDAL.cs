using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class CustomersDAL : BaseDAL
    {
        public int AddCustomer(CustomersDTO customerDTO)
        {
            return SaveCustomer(customerDTO);
        }

        public CustomersDTO checkCustomer(int customerId)
        {
            CustomersDTO customerDTO = new CustomersDTO();
            customerDTO = CustomerCheck(customerId);
            return customerDTO;
        }
        
        public int updateCustomer(CustomersDTO customerDTO)
        {
            return CustomerUpdate(customerDTO);
        }

        public List<CustomersDTO> findCustomers(CustomersDTO customerDTO)
        {
            List<CustomersDTO> list = new List<CustomersDTO>();
            list = CustomersFind(customerDTO);
            return list;
        }

        public int deleteCustomer(int customerId)
        {
            return CustomerDelete(customerId);
        }
    }
}
