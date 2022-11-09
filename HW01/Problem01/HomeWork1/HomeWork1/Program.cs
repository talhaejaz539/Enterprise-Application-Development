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
            int id;
            string name;
            string cnic;
            string phoneNumber;
            string disease;
            string isAdmitted;

            int input = 0;

            do
            {
                Console.WriteLine("\n1. Add Patient");
                Console.WriteLine("2. Delete Patient");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Search Patient");
                Console.WriteLine("5. Display All Patients");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter Your Choice: ");
                input = Convert.ToInt32(Console.ReadLine());

                if(input == 1)
                {

                    Console.WriteLine("Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("CNIC: ");
                    cnic = Console.ReadLine();
                    Console.WriteLine("Phone Number: ");
                    phoneNumber = Console.ReadLine();
                    Console.WriteLine("Disease: ");
                    disease = Console.ReadLine();
                    Console.WriteLine("isAdmitted: ");
                    isAdmitted = Console.ReadLine();

                    Patient patient = new Patient
                    {
                        Name = name,
                        CNIC = cnic,
                        PhoneNumber = phoneNumber,
                        Disease = disease,
                        IsAdmitted = isAdmitted
                    };

                    Patient.addPatient(patient);
                }

                if(input == 2)
                {
                    Console.WriteLine("Enter Id to Delete");
                    id = Convert.ToInt32(Console.ReadLine());
                    Patient.deletePatient(id);
                }

                if(input == 3)
                {
                    Console.WriteLine("Enter Id to Update: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("CNIC: ");
                    cnic = Console.ReadLine();
                    Console.WriteLine("Phone Number: ");
                    phoneNumber = Console.ReadLine();
                    Console.WriteLine("Disease: ");
                    disease = Console.ReadLine();
                    Console.WriteLine("isAdmitted: ");
                    isAdmitted = Console.ReadLine();

                    Patient patient = new Patient
                    {
                        Id = id,
                        Name = name,
                        CNIC = cnic,
                        PhoneNumber = phoneNumber,
                        Disease = disease,
                        IsAdmitted = isAdmitted
                    };

                    Patient.updatePatient(id, patient);
                }

                if(input == 4)
                {
                    Console.WriteLine("Enter Id to Search");
                    id = Convert.ToInt32(Console.ReadLine());
                    Patient.searchPatient(id);
                }

                if(input == 5)
                {
                    Patient.displayAll();
                }

                if(input == 6)
                {
                    Patient.UpdateRecords();
                }

            } while (input != 6);
        }
    }
}
