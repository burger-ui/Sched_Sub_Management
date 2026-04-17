using System;
using SSM_BL;

namespace SSM_UI
{
    public class Program
    {
        static AddSubBL added = new AddSubBL();
        static string connectionString = "Server=localhost\\SQLEXPRESS01;Database=SSM_DB;Trusted_Connection=True;";

        public static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Menu();
                string choice = Console.ReadLine();

                if (choice == "1") Add();
                else if (choice == "2") Show();
                else if (choice == "3") Remove();
                else if (choice == "4") added.SaveDataToJson("subjects.json");
                else if (choice == "5") added.LoadDataFromJson("subjects.json");
                else if (choice == "6") added.SaveDataToSql(connectionString);
                else if (choice == "7") added.LoadDataFromSql(connectionString);
                else if (choice == "8")
                {
                    running = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                }
                else Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        static void Menu()
        {
            Console.WriteLine("\nSubject Schedule Management");
            Console.WriteLine("1. Add Subject");
            Console.WriteLine("2. Show Subjects");
            Console.WriteLine("3. Remove Subject");
            Console.WriteLine("4. Save to JSON");
            Console.WriteLine("5. Load from JSON");
            Console.WriteLine("6. Save to SQL");
            Console.WriteLine("7. Load from SQL");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
        }

        static void Add()
        {
            Console.Write("Enter Subject Name: ");
            string subjectName = Console.ReadLine();
            Console.Write("Enter Schedule: ");
            string schedule = Console.ReadLine();
            added.AddSubject(subjectName, schedule);
        }

        static void Show()
        {
            Console.WriteLine("\nSubjects and Schedules:");
            added.ShowSubjects();
        }

        static void Remove()
        {
            Console.WriteLine("\nEnter the number of the subject to remove:");
            added.ShowSubjects();
            Console.Write("Subject number: ");
            if (int.TryParse(Console.ReadLine(), out int subjectIndex))
                added.RemoveSubject(subjectIndex - 1);
            else
                Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}
