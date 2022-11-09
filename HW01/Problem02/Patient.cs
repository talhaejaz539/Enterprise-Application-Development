using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PatientClassLibrary
{
    public class Patient
    {
        public static int count = 0;

        public static List<Patient> list = new List<Patient>();

        public Patient()
        {
            this.id = ++count;
        }

        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Name { get; set; }

        public String CNIC { get; set; }

        public String PhoneNumber { get; set; }
        public String Disease { get; set; }
        public String IsAdmitted { get; set; }

        public static void addPatient(Patient patient)
        {
            list.Add(patient);
            FileStream fout = new FileStream("Patient.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fout);

            sw.WriteLine(patient.Id + " " + patient.Name + " " + patient.CNIC + " " + patient.PhoneNumber + " " +
                patient.Disease + " " + patient.IsAdmitted);
            
            sw.Close();
            fout.Close();
        }

        public static void deletePatient(int id)
        {
            int index = 0;
            while(index < list.Count)
            {
                if(list[index].Id == id)
                {
                    list.RemoveAt(index);
                    return;
                }
                index++;
            }
            Console.WriteLine("Patient not found");
        }

        public static void updatePatient(int id, Patient p)
        {
            int index = 0;
            while(index < list.Count)
            {
                if(list[index].Id == id)
                {
                    list.RemoveAt(index);
                    list.Insert(index, p);
                    return;
                }
                index++;
            }
            Console.WriteLine("Patient not found");
        }

        public static void searchPatient(int id)
        {
            for(int index = 0; index < list.Count; index++)
            {
                if (id == list[index].Id)
                    Console.WriteLine(list[index].ToString());
            }
        }

        public static void displayAll()
        {
            Console.WriteLine("\tData From List\n");

            foreach (Patient p in list)
            {
                Console.WriteLine(p);
            }
        }

        public static void UpdateRecords()
        {
            FileStream fout = new FileStream("Patient.txt", FileMode.Truncate);
            StreamWriter sw = new StreamWriter(fout);

            foreach(Patient patient in list)
            {
                sw.WriteLine(patient.Id + " " + patient.Name + " " + patient.CNIC + " " + patient.PhoneNumber + " " +
                patient.Disease + " " + patient.IsAdmitted);
            }

            sw.Close();
            fout.Close();
        }

        public override String ToString()
        {
            return "Name: " + this.Name + "\nCNIC: " + this.CNIC + "\nPhone: " + this.PhoneNumber + "\nDisease: " + this.Disease + "\nCurrently Admited: " + this.IsAdmitted;
        }
    }
}
