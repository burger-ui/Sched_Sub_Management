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

                switch (choice)
                {
                    case "1": Add(); break;
                    case "2": Show(); break;
                    case "3": Remove(); break;
                    case "4": added.SaveDataToJson("subjects.json"); break;
                    case "5": added.LoadDataFromJson("subjects.json"); break;
                    case "6": AddDb(); break;
                    case "7": ShowDb(); break;
                    case "8": RemoveDb(); break;
                    case "9":
                        running = false;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
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
            Console.WriteLine("6. Add Subject to DB");
            Console.WriteLine("7. Show Subjects from DB");
            Console.WriteLine("8. Remove Subject from DB");
            Console.WriteLine("9. Exit");
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

        static void AddDb()
        {
            Console.Write("Enter Subject Name: ");
            string subjectName = Console.ReadLine();
            Console.Write("Enter Schedule: ");
            string schedule = Console.ReadLine();
            added.AddSubjectToDb(subjectName, schedule);
        }

        static void ShowDb()
        {
            Console.WriteLine("\nSubjects from Database:");
            added.ShowSubjectsFromDb();
        }

        static void RemoveDb()
        {
            Console.Write("Enter Subject Name to remove: ");
            string subjectName = Console.ReadLine();
            added.RemoveSubjectFromDb(subjectName);
        }
    }
}
