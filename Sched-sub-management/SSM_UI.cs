using System;
using SSM_BL;

namespace SSM_UI

{
    public class Program
    {
        static AddSubBL added = new AddSubBL();

        public static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Menu();
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    add();
                }
                else if (choice == "2")
                {
                    show();
                }
                else if (choice == "3")
                {
                    remove();
                }
                else if (choice == "4")
                {
                    running = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("\nSubject Schedule Management");
            Console.WriteLine("1. Add Subject");
            Console.WriteLine("2. Show Subjects");
            Console.WriteLine("3. Remove Subject");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
        }

        static void add()
        {
            Console.Write("Enter Subject Name: ");
            string subjectName = Console.ReadLine();
            Console.Write("Enter Schedule: ");
            string schedule = Console.ReadLine();
            added.AddSubject(subjectName, schedule);
        }

        static void show()
        {
            Console.WriteLine("\nSubjects and Schedules:");
            added.ShowSubjects();
        }

        static void remove()
        {
            Console.WriteLine("\nEnter the number of the subject to remove:");
            added.ShowSubjects();
            Console.Write("Subject number: ");
            if (int.TryParse(Console.ReadLine(), out int subjectIndex))
            {
                added.RemoveSubject(subjectIndex);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}