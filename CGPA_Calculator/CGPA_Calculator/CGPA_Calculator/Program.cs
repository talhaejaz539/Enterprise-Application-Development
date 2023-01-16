
double sgpa = 0.0;

void func(int k)
{
    Console.Write($"\n\t\tEnter Semester {k + 1} Subjects: ");
    int size = int.Parse(Console.ReadLine());

    int []num = new int[size];
    double []credithrs = new double[size];
    double totalCreditHrs = 0.0;
    double total = 0.0;

    for (int i = 0; i < size; i++)
    {

        int j = i;
        j++;
        Console.Write($"\n\t\t\tSubject {j} Marks: ");
        num[i] = int.Parse(Console.ReadLine());

        Console.Write($"\t\t\tSubject {j} Credit Hrs: ");
        credithrs[i] = Double.Parse(Console.ReadLine());
        totalCreditHrs += credithrs[i];

        if (num[i] >= 85)
            total = total + (credithrs[i] * 4.00);
        else if (num[i] >= 80 && num[i] <= 84)
            total = total + (credithrs[i] * 3.70);
        else if (num[i] >= 75 && num[i] <= 79)
            total = total + (credithrs[i] * 3.30);
        else if (num[i] >= 70 && num[i] <= 74)
            total = total + (credithrs[i] * 3.00);
        else if (num[i] >= 65 && num[i] <= 69)
            total = total + (credithrs[i] * 2.70);
        else if (num[i] >= 61 && num[i] <= 64)
            total = total + (credithrs[i] * 2.30);
        else if (num[i] >= 58 && num[i] <= 60)
            total = total + (credithrs[i] * 2.00);
        else if (num[i] >= 55 && num[i] <= 57)
            total = total + (credithrs[i] * 1.70);
        else if (num[i] >= 50 && num[i] <= 54)
            total = total + (credithrs[i] * 1.00);
        else if (num[i] < 50)
            total = total + (credithrs[i] * 0.00);

    }

    double sgpaIndex = total / totalCreditHrs;
    sgpa += sgpaIndex;
    Console.WriteLine($"\n\t\t\t\tSemester {k + 1} SGPA: {sgpaIndex}");
    Console.ReadKey(true);
}


Console.Write("\n\tEnter Total Semesters: ");
int totalSemesters = int.Parse(Console.ReadLine());

for(int i = 0; i < totalSemesters; i++)
{
    func(i);
    Console.Clear();
}

double cgpa = sgpa / totalSemesters;
Console.Write($"\n\n\n\t\t\t\tCGPA Till {totalSemesters} Semesters: {cgpa}");
Console.ReadKey(true);
Console.WriteLine("\n\n\n");