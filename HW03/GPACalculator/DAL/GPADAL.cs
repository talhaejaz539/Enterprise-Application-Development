using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DTO;

namespace DAL
{
    public class GPADAL : BaseDAL
    {
        public int SaveGPA(GPADTO dto)
        {
            int count = Save(dto);
            return count;
        }

        public List<GPADTO> GetData()
        {
            List<GPADTO> dtos = Read();
            return dtos;
        }

        public bool CheckDB()
        {
            return CheckData();
        }
    }
}
