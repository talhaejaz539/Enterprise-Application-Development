using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DAL
{
    public class BaseDAL
    {
        protected void Save(string filename, string line)
        {
            StreamWriter sw = new StreamWriter(filename, append: false);

            sw.Write(line);

            sw.Close();
        }

        protected string Read(string filename)
        {
            StreamReader sr = new StreamReader(filename);

            string data = sr.ReadLine();

            sr.Close();
            return data;
        }
    }
}
