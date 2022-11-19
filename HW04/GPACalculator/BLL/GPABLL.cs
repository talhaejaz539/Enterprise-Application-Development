using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public class GPABLL
    {
        public void AddGPA(GPADTO dto)
        {
            dto.Grade = findGrade(dto.Marks);
            GPADAL dal = new GPADAL();
            dal.SaveGPA(dto);
        }

        private string findGrade(int marks)
        {
            if (marks >= 85 && marks <= 100)
                return "A";
            else if (marks >= 80 && marks <= 84)
                return "A-";
            else if (marks >= 75 && marks <= 79)
                return "B+";
            else if (marks >= 70 && marks <= 74)
                return "B";
            else if (marks >= 65 && marks <= 69)
                return "B-";
            else if (marks >= 61 && marks <= 64)
                return "C+";
            else if (marks >= 58 && marks <= 60)
                return "C";
            else if (marks >= 55 && marks <= 57)
                return "C-";
            else if (marks >= 50 && marks <= 54)
                return "D";
            else if (marks < 50)
                return "F";
            //Base
            return "Impossible To Find Grade!";
        }

        public GPADTO GetGPAData()
        {
            GPADAL data = new GPADAL();
            GPADTO gpaData = new GPADTO();
            gpaData = data.GetData();

            gpaData.GPA = findGPA(gpaData.Grade);

            return gpaData;
        }

        private string findGPA(string grade)
        {
            if (grade.Equals("A")) return 4.00f.ToString("0.00");
            else if (grade.Equals("A-")) return 3.70f.ToString("0.00");
            else if (grade.Equals("B+")) return 3.30f.ToString("0.00");
            else if (grade.Equals("B")) return 3.00f.ToString("0.00");
            else if (grade.Equals("B-")) return 2.70f.ToString("0.00");
            else if (grade.Equals("C+")) return 2.30f.ToString("0.00");
            else if (grade.Equals("C")) return 2.00f.ToString("0.00");
            else if (grade.Equals("C-")) return 1.70f.ToString("0.00");
            else if (grade.Equals("D")) return 1.00f.ToString("0.00");
            else if (grade.Equals("F")) return 0.00f.ToString("0.00");
            //Base
            return "0.00";
        }

        public bool Check()
        {
            GPADAL checking = new GPADAL();
            return checking.CheckFile();
        }
    }
}
