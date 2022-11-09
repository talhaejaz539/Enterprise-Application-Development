﻿using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using BLL;

namespace PL
{
    public class GPAView
    {
        public void InputData()
        {
            
            Console.Write(" Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Roll Number: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string roll_Number = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Subject Title: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string subject_title = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Marks: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int marks = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            GPADTO dto = new GPADTO
            {
                Name = name,
                RollNumber = roll_Number,
                SubjectTitle = subject_title,
                Marks = marks
            };

            GPABLL bll = new GPABLL();
            bll.AddGPA(dto);
        }

        public void OutputData()
        {
            GPABLL bll = new GPABLL();
            if (bll.Check() == false)
            {
                Console.WriteLine("\n\tThe file is empty or does not exist.\n");
            }
            
            else
            {
                GPADTO gpaData = bll.GetGPAData();

                Console.Write(" Name: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(gpaData.Name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Roll Number: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(gpaData.RollNumber);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Subject Title: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(gpaData.SubjectTitle);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" GPA: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(gpaData.GPA);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}