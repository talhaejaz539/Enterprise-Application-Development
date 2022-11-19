using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class BaseDAL
    {
        protected int Save(GPADTO gpa)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GPADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"INSERT INTO GPA (name, rollnumber, subjecttitle, grade) VALUES (@name, @roll, @subject, @grade)";
            cmd.CommandText = query;
            SqlParameter p1 = new SqlParameter("name", gpa.Name);
            SqlParameter p2 = new SqlParameter("roll", gpa.RollNumber);
            SqlParameter p3 = new SqlParameter("subject", gpa.SubjectTitle);
            SqlParameter p4 = new SqlParameter("grade", gpa.Grade);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            con.Open();

            int count = cmd.ExecuteNonQuery();

            con.Close();

            return count;
        }

        protected List<GPADTO> Read()
        {
            List<GPADTO> list = new List<GPADTO>();
            //GPADTO dto = new GPADTO();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GPADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"SELECT * FROM GPA";
            cmd.CommandText = query;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                GPADTO dto = new GPADTO();
                dto.Name = dr.GetString(1);
                dto.RollNumber = dr.GetString(2);
                dto.SubjectTitle = dr.GetString(3);
                //byte[] byy = Encoding.ASCII.GetBytes(dr.GetString(4));
                //foreach (byte b in byy)
                //{
                //    Console.WriteLine(b);
                //}
                dto.Grade = dr.GetString(4);
                list.Add(dto);
            }
            con.Close();

            return list;
        }

        protected bool CheckData()
        {
            bool flag = false;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GPADB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = $"SELECT * FROM GPA";
            cmd.CommandText = query;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
                flag = true;

            con.Close();
            return flag;
        }
    }
}
