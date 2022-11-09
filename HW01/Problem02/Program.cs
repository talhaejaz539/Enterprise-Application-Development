using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PatientClassLibrary;

namespace HomeWork1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Patient patient = new Patient 
            {
                Id = Convert.ToInt32(args[0]),
                Name = Convert.ToString(args[1]),
                CNIC = Convert.ToString(args[2]),
                PhoneNumber = Convert.ToString(args[3]),
                Disease = Convert.ToString(args[4]),
                IsAdmitted = Convert.ToString(args[5])
            };
            Console.WriteLine(patient.ToString());
        }
    }
}
