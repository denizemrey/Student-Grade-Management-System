using System;
using System.Collections.Generic;

namespace StudentGradeManagement
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Grade> Grade { get; set; } = new List<Grade>();
    }

    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Lesson { get; set; }
        public double Point { get; set; }
        public string LetterGrade { get; set; }
    }

    public class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n=== Student Grade Management System ===");
                Console.WriteLine("1. List Students");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Add Grade");
                Console.WriteLine("4. View Student Grades");
                Console.WriteLine("5. Exit");
                Console.Write("Your Choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListStudents();
                        break;
                    case "2":
                        AddStudent();
                        break;
                    case "3":
                        AddGrade();
                        break;
                    case "4":
                        ViewStudentGrades();
                        break;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("\nExiting the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\n[!] Invalid Choice. Please try again.");
                        break;
                }
            }
        }

        static void ListStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\n[!] No added Student!");
            }
            else
            {
                Console.WriteLine("\n---> List of Students:");
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"- Name: {students[i].Name} {students[i].Surname} | Id: {students[i].Id} | Registered Grades: {students[i].Grade.Count}");
                }
            }
        }

        static void AddStudent()
        {
            Student newStudent = new Student();

            Console.WriteLine("\n--- Add New Student ---");
            Console.Write("Name: ");
            newStudent.Name = Console.ReadLine();

            Console.Write("Surname: ");
            newStudent.Surname = Console.ReadLine();

            Console.Write("Id: ");
            newStudent.Id = Convert.ToInt32(Console.ReadLine());

            students.Add(newStudent);
            Console.WriteLine("\n[+] Student added successfully!");
        }

        static void AddGrade()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\n[!] No added student!");
            }
            else
            {
                Console.WriteLine("\n--- Add Grade ---");
                Console.Write("Enter Student Id to add grade: ");
                int targetId = Convert.ToInt32(Console.ReadLine());

                bool isFound = false;

                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Id == targetId)
                    {
                        isFound = true;

                        Grade newGrade = new Grade();

                        Console.Write("Lesson: ");
                        newGrade.Lesson = Console.ReadLine();

                        Console.Write("Point: ");
                        newGrade.Point = Convert.ToDouble(Console.ReadLine());

                        if (newGrade.Point >= 90)
                        {
                            newGrade.LetterGrade = "AA";
                        }
                        else if (newGrade.Point >= 80)
                        {
                            newGrade.LetterGrade = "BA";
                        }
                        else if (newGrade.Point >= 70)
                        {
                            newGrade.LetterGrade = "BB";
                        }
                        else if (newGrade.Point >= 60)
                        {
                            newGrade.LetterGrade = "CB";
                        }
                        else if (newGrade.Point >= 50)
                        {
                            newGrade.LetterGrade = "CC";
                        }
                        else
                        {
                            newGrade.LetterGrade = "FF";
                        }

                        students[i].Grade.Add(newGrade);
                        Console.WriteLine("\n[+] Grade added successfully!");
                        break;
                    }
                }

                if (isFound == false)
                {
                    Console.WriteLine("\n[!] No founded student.");
                }
            }
        }

        static void ViewStudentGrades()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\n[!] No added student!");
            }
            else
            {
                Console.WriteLine("\n=== Student Records and Grades ===");

                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"\nStudent: {students[i].Name} {students[i].Surname} (Id: {students[i].Id})");

                    if (students[i].Grade.Count == 0)
                    {
                        Console.WriteLine("  -> No grades added yet.");
                    }
                    else
                    {
                        double sum = 0;

                        for (int j = 0; j < students[i].Grade.Count; j++)
                        {
                            Console.WriteLine($"  -> Lesson: {students[i].Grade[j].Lesson} | Point: {students[i].Grade[j].Point} | Letter: {students[i].Grade[j].LetterGrade}");
                            sum += students[i].Grade[j].Point;
                        }

                        double average = sum / students[i].Grade.Count;
                        Console.WriteLine($"  => Average Grade: {average:F2}");
                    }
                }
                Console.WriteLine("\n==================================");
            }
        }
    }
}