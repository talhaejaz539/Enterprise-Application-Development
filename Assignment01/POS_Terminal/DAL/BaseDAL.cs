using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class BaseDAL
    {
        // Item Modules Start
        // Add New Item
        protected int SaveItem(ItemsDTO itemDTO)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"INSERT INTO items (Description, Price, Quantity, CreationDate) " +
                $"VALUES (@des, @price, @quantity, @cDate)";
            cmd.CommandText = query;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("des", itemDTO.Description),
                new SqlParameter("price", itemDTO.Price),
                new SqlParameter("quantity", itemDTO.Quantity),
                new SqlParameter("cDate", itemDTO.CreationDate)
            };
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            cmd.Parameters.Add(parameters[2]);
            cmd.Parameters.Add(parameters[3]);

            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();

            return count;
        }

        // Check Item Exist or not
        protected ItemsDTO ItemCheck(int itemId)
        {
            ItemsDTO itemsDTO = null;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"SELECT * FROM items WHERE ItemId = @itemId";
            cmd.CommandText = query;
            SqlParameter p1 = new SqlParameter("itemId", itemId);
            cmd.Parameters.Add(p1);

            con.Open();
            SqlDataReader data = cmd.ExecuteReader();

            if(data.Read()) {
                itemsDTO = new ItemsDTO();
                itemsDTO.Id = data.GetInt32(0);
                itemsDTO.Description = data.GetString(1);
                itemsDTO.Price = data.GetInt32(2);
                itemsDTO.Quantity = data.GetInt32(3);
                itemsDTO.CreationDate = data.GetDateTime(4);
            }

            con.Close();

            return itemsDTO;
        }

        // Update Existing Item
        protected int ItemUpdate(ItemsDTO itemDTO)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"UPDATE items SET Description = @des, Price = @price, Quantity = @quantity, " +
                $"CreationDate = @cDate WHERE ItemId = @id";
            cmd.CommandText = query;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("des", itemDTO.Description),
                new SqlParameter("price", itemDTO.Price),
                new SqlParameter("quantity", itemDTO.Quantity),
                new SqlParameter("cDate", itemDTO.CreationDate),
                new SqlParameter("id", itemDTO.Id)
            };
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            cmd.Parameters.Add(parameters[2]);
            cmd.Parameters.Add(parameters[3]);
            cmd.Parameters.Add(parameters[4]);

            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();

            return count;
        }

        // Find item on given data
        protected List<ItemsDTO> itemsFind(ItemsDTO itemDTO)
        {
            List<ItemsDTO> list = null;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"SELECT * FROM items WHERE ItemId = @id OR Description = @des OR Price = @price" +
                $" OR Quantity = @quantity OR CreationDate = @cDate";
            cmd.CommandText = query;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("id", itemDTO.Id),
                new SqlParameter("des", itemDTO.Description),
                new SqlParameter("price", itemDTO.Price),
                new SqlParameter("quantity", itemDTO.Quantity),
                new SqlParameter("cDate", itemDTO.CreationDate?? DateTime.Now)
            };
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            cmd.Parameters.Add(parameters[2]);
            cmd.Parameters.Add(parameters[3]);
            cmd.Parameters.Add(parameters[4]);

            con.Open();
            SqlDataReader data = cmd.ExecuteReader();

            if (data.HasRows)
            {
                list = new List<ItemsDTO>();
                while(data.Read())
                {
                    ItemsDTO itemsDTO = new ItemsDTO();
                    itemsDTO.Id = data.GetInt32(0);
                    itemsDTO.Description = data.GetString(1);
                    itemsDTO.Price = data.GetInt32(2);
                    itemsDTO.Quantity = data.GetInt32(3);
                    itemsDTO.CreationDate = data.GetDateTime(4);
                    list.Add(itemsDTO);
                }
            }

            con.Close();

            return list;
        }

        // Delete item
        public int itemDelete(int itemId)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string query1 = $"SELECT * FROM SaleLineItems WHERE ItemId = @itemid";
            cmd.CommandText = query1;
            SqlParameter p2 = new SqlParameter("itemid", itemId);
            cmd.Parameters.Add(p2);

            con.Open();
            int count = 0;
            SqlDataReader data = cmd.ExecuteReader();
            if(!data.HasRows)
            {
                string query = $"DELETE FROM items WHERE ItemId = @id";
                cmd.CommandText = query;
                SqlParameter p1 = new SqlParameter("id", itemId);
                cmd.Parameters.Add(p1);

                con.Open();
                count = cmd.ExecuteNonQuery();
                con.Close();
            }
            con.Close();

            return count;
        }
        // Item Modules End


        // Customer Modules Start
        // Add Customer
        protected int SaveCustomer(CustomersDTO customerDTO)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"INSERT INTO Customers (Name, Address, Phone, Email, AmountPayable, SalesLimit) " +
                $"VALUES (@name, @address, @phone, @email, @amountPayable, @saleslimit)";
            cmd.CommandText = query;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("name", customerDTO.Name),
                new SqlParameter("address", customerDTO.Address),
                new SqlParameter("phone", customerDTO.Phone),
                new SqlParameter("email", customerDTO.Email),
                new SqlParameter("amountPayable", customerDTO.AmountPayable),
                new SqlParameter("salesLimit", customerDTO.SalesLimit)
            };
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            cmd.Parameters.Add(parameters[2]);
            cmd.Parameters.Add(parameters[3]);
            cmd.Parameters.Add(parameters[4]);
            cmd.Parameters.Add(parameters[5]);

            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();

            return count;
        }

        // Check Customer Exist or not
        protected CustomersDTO CustomerCheck(int customerId) 
        {
            CustomersDTO customerDTO = null;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"SELECT * FROM Customers WHERE CustomerId = @customerId";
            cmd.CommandText = query;
            SqlParameter p1 = new SqlParameter("customerId", customerId);
            cmd.Parameters.Add(p1);

            con.Open();
            SqlDataReader data = cmd.ExecuteReader();

            if (data.Read())
            {
                customerDTO = new CustomersDTO();
                customerDTO.Id = data.GetInt32(0);
                customerDTO.Name = data.GetString(1);
                customerDTO.Address = data.GetString(2);
                customerDTO.Phone = data.GetString(3);
                customerDTO.Email = data.GetString(4);
                customerDTO.SalesLimit = data.GetInt32(6);
            }

            con.Close();
            return customerDTO;
        }

        // Update Existing Customer
        protected int CustomerUpdate(CustomersDTO customerDTO)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"UPDATE Customers SET Name = @name, Address = @address, Phone = @phone, Email = @email," +
                $" SalesLimit = @salesLimit WHERE CustomerId = @id";
            cmd.CommandText = query;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("name", customerDTO.Name),
                new SqlParameter("address", customerDTO.Address),
                new SqlParameter("phone", customerDTO.Phone),
                new SqlParameter("email", customerDTO.Email),
                new SqlParameter("salesLimit", customerDTO.SalesLimit),
                new SqlParameter("id", customerDTO.Id)
            };
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            cmd.Parameters.Add(parameters[2]);
            cmd.Parameters.Add(parameters[3]);
            cmd.Parameters.Add(parameters[4]);
            cmd.Parameters.Add(parameters[5]);

            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();

            return count;
        }

        // Find Customer
        protected List<CustomersDTO> CustomersFind(CustomersDTO customerDTO)
        {
            List<CustomersDTO> list = null;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"SELECT * FROM customers WHERE CustomerId = @id OR Name = @name OR Email = @email" +
                $" OR Phone = @phone OR SalesLimit = @salesLimit";
            cmd.CommandText = query;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("id", customerDTO.Id),
                new SqlParameter("name", customerDTO.Name),
                new SqlParameter("email", customerDTO.Email),
                new SqlParameter("phone", customerDTO.Phone),
                new SqlParameter("salesLimit", customerDTO.SalesLimit)
            };
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            cmd.Parameters.Add(parameters[2]);
            cmd.Parameters.Add(parameters[3]);
            cmd.Parameters.Add(parameters[4]);

            con.Open();
            SqlDataReader data = cmd.ExecuteReader();

            if (data.HasRows)
            {
                list = new List<CustomersDTO>();
                while (data.Read())
                {
                    CustomersDTO customers = new CustomersDTO();
                    customers.Id = data.GetInt32(0);
                    customers.Name = data.GetString(1);
                    customers.Phone = data.GetString(3);
                    customers.Email = data.GetString(4);
                    customers.SalesLimit = data.GetInt32(6);
                    list.Add(customers);
                }
            }

            con.Close();

            return list;
        }

        // Delete Customer
        public int CustomerDelete(int customerId)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string query1 = $"SELECT * FROM Sales WHERE CustomerId = @custId";
            cmd.CommandText = query1;
            SqlParameter p2 = new SqlParameter("custId", customerId);
            cmd.Parameters.Add(p2);
            
            con.Open();
            int count = 0;
            SqlDataReader data = cmd.ExecuteReader();
            if(!data.HasRows)
            {
                con.Close();
                string query = $"DELETE FROM customers WHERE CustomerId = @id";
                cmd.CommandText = query;
                SqlParameter p1 = new SqlParameter("id", customerId);
                cmd.Parameters.Add(p1);

                con.Open();
                count = cmd.ExecuteNonQuery();
                con.Close();
            }
            //con.Close();

            return count;
        }

        // Add Sales
        public bool salesAdd(SalesDTO salesDTO, List<SaleLineItemsDTO> saleLineItemsList)
        {
            bool flag = false;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string query5 = $"SELECT * FROM Customers WHERE CustomerId = @cutId";
            cmd.CommandText = query5;
            SqlParameter p5 = new SqlParameter("cutId", salesDTO.CustomerId);
            cmd.Parameters.Add(p5);

            con.Open();
            SqlDataReader data1 = cmd.ExecuteReader();
            int amountPayable = 0;
            if (data1.Read())
                amountPayable = data1.GetInt32(5);
            con.Close();

            string query = $"UPDATE Customers SET AmountPayable = @amount WHERE CustomerId = @custId";
            cmd.CommandText = query;
            SqlParameter p1 = new SqlParameter("amount", salesDTO.TotalSales + amountPayable);
            SqlParameter p2 = new SqlParameter("custId", salesDTO.CustomerId);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();

            string query1 = $"INSERT INTO Sales (CustomerId, Status, Date) VALUES (@customerId, @status, @date)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("customerId", salesDTO.CustomerId),
                new SqlParameter("status", salesDTO.Status),
                new SqlParameter("date", salesDTO.SaleDateTime)
            };
            cmd.CommandText = query1;
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            cmd.Parameters.Add(parameters[2]);

            con.Open();
            int count1 = cmd.ExecuteNonQuery();
            con.Close();

            string query2 = $"SELECT * FROM Sales ORDER by orderId DESC";
            cmd.CommandText = query2;

            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            
            if (data.Read())
                salesDTO.OrderId = data.GetInt32(0);
            con.Close();

            int count2 = 0;
            foreach(var item in saleLineItemsList)
            {
                string query3 = $"INSERT INTO SaleLineItems (OrderId, ItemId, Quantity, Amount) " +
                    $"VALUES ({salesDTO.OrderId}, {item.ItemId}, {item.Quantity}, {item.Amount})";
                cmd.CommandText = query3;
                con.Open();
                int ucount = cmd.ExecuteNonQuery();
                con.Close();
                count2 += ucount;
            }
            

            if (count == 1 && count1 == 1 && count2 == saleLineItemsList.Count)
                flag = true;

            return flag;
        }

        // Check Payments
        public PaymentsDTO PaymentCheck(int saleId)
        {
            PaymentsDTO payment = new PaymentsDTO();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string query = $"SELECT * FROM Customers, Sales WHERE (Customers.CustomerId = Sales.CustomerId AND Sales.OrderId = @saleId)";
            SqlParameter p1 = new SqlParameter("saleId", saleId);
            cmd.Parameters.Add(p1);
            cmd.CommandText = query;
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            if (data.Read())
                payment.CustomerName = data.GetString(1);
            con.Close();

            string query1 = $"SELECT * FROM SaleLineItems WHERE OrderId = @saledId";
            SqlParameter p2 = new SqlParameter("saledId", saleId);
            cmd.Parameters.Add(p2);
            cmd.CommandText = query1;
            con.Open();
            SqlDataReader data1 = cmd.ExecuteReader();
            int totalSalesAmount = 0;
            while (data1.Read())
            {
                totalSalesAmount += data1.GetInt32(4);
            }
            payment.TotalSalesAmount = totalSalesAmount;
            con.Close();

            string query2 = $"SELECT * FROM Receipts WHERE OrderId = @salId";
            SqlParameter p3 = new SqlParameter("salId", saleId);
            cmd.Parameters.Add(p3);
            cmd.CommandText = query2;
            con.Open();
            SqlDataReader data2 = cmd.ExecuteReader();
            int amountPaid = 0;
            while (data2.Read())
            {
                amountPaid += data2.GetInt32(3);
            }
            payment.AmountPaid = amountPaid;
            con.Close();

            payment.RemainingAmount = totalSalesAmount - amountPaid;

            return payment;
        }

        // New Receipt
        public int ReceiptMake(ReceiptDTO receiptDTO)
        {
            int flag = 0;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PointOfSale;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string query = $"SELECT * FROM Customers, Sales WHERE (Customers.CustomerId = Sales.CustomerId AND Sales.OrderId = @orderId)";
            SqlParameter p1 = new SqlParameter("orderId", receiptDTO.OrderId);
            cmd.Parameters.Add(p1);
            cmd.CommandText = query;
            con.Open();
            int customerAmountPayable = 0;
            int custId = 0;
            SqlDataReader data = cmd.ExecuteReader();
            if (data.Read())
            {
                customerAmountPayable = data.GetInt32(5);
                custId = data.GetInt32(0);
            }
            con.Close();

            string query1 = $"UPDATE Customers SET AmountPayable = @amount WHERE CustomerId = @custId";
            cmd.CommandText = query1;
            SqlParameter p2 = new SqlParameter("amount", (customerAmountPayable - receiptDTO.AmountToBePaid));
            SqlParameter p3 = new SqlParameter("custId", custId);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);

            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();

            string query2 = $"INSERT INTO Receipts (ReceiptDate, OrderId, Amount) VALUES (@rDate, @ordeId, @amout)";
            cmd.CommandText = query2;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("rDate", receiptDTO.ReceiptDateTime),
                new SqlParameter("ordeId", receiptDTO.OrderId),
                new SqlParameter("amout", receiptDTO.AmountToBePaid)
            };
            cmd.Parameters.Add(parameters[0]);
            cmd.Parameters.Add(parameters[1]);
            cmd.Parameters.Add(parameters[2]);

            con.Open();
            int count1 = cmd.ExecuteNonQuery();
            con.Close();

            if (count == 1 && count1 == 1)
                return 1;

            return flag;
        }
    }
}
