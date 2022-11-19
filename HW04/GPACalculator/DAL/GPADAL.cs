using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using DTO;

namespace DAL
{
    public class GPADAL : BaseDAL
    {
        public void SaveGPA(GPADTO dto)
        {
            string jsonString = JsonSerializer.Serialize(dto);
            Save("GPA.txt", jsonString);
        }

        public GPADTO GetData()
        {
            string data = Read("GPA.txt");

            GPADTO gpaData = JsonSerializer.Deserialize<GPADTO>(data);

            return gpaData;
        }

        public bool CheckFile()
        {
            if (File.Exists("GPA.txt"))
            {
                if (new FileInfo("GPA.txt").Length == 0)
                    return false;
                return true;
            }
            return false;
        }
    }
}
