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
                    case "4": added.SaveDataToJson("subjects.json"); Console.WriteLine("Saved."); break;
                    case "5": added.LoadDataFromJson("subjects.json"); Console.WriteLine("Loaded."); break;
                    case "6": AddDb(); break;
                    case "7": ShowDb(); break;
                    case "8": RemoveDb(); break;
                    case "9":
                        running = false;
                        Console.WriteLine("Exiting. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("\n=== Subject Schedule Management ===");
            Console.WriteLine("1. Add Subject (Memory)");
            Console.WriteLine("2. Show Subjects (Memory)");
            Console.WriteLine("3. Remove Subject (Memory)");
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
            Console.WriteLine($"Added: {subjectName} - {schedule}");
        }

        // FIX: was calling GetSubjectsFromMemory() but never printing the result
        static void Show()
        {
            Console.WriteLine("\nSubjects in Memory:");
            var subjects = added.GetSubjectsFromMemory();
            if (subjects.Count == 0)
                Console.WriteLine("No subjects in memory.");
            else
                for (int i = 0; i < subjects.Count; i++)
                    Console.WriteLine($"  {i + 1}. {subjects[i]}");
        }

        // FIX: was calling Show() which re-prints header; now lists then asks for index
        static void Remove()
        {
            var subjects = added.GetSubjectsFromMemory();
            if (subjects.Count == 0)
            {
                Console.WriteLine("No subjects to remove.");
                return;
            }

            Console.WriteLine("\nSelect subject to remove:");
            for (int i = 0; i < subjects.Count; i++)
                Console.WriteLine($"  {i + 1}. {subjects[i]}");

            Console.Write("Subject number: ");
            if (int.TryParse(Console.ReadLine(), out int subjectIndex))
            {
                bool removed = added.RemoveSubject(subjectIndex - 1);
                Console.WriteLine(removed ? "Removed successfully." : "Invalid number.");
            }
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
            Console.WriteLine($"Added to DB: {subjectName} - {schedule}");
        }

        // FIX: was calling GetSubjectsFromDb() but never printing the result
        static void ShowDb()
        {
            Console.WriteLine("\nSubjects from Database:");
            var subjects = added.GetSubjectsFromDb();
            if (subjects.Count == 0)
                Console.WriteLine("No subjects in DB.");
            else
                for (int i = 0; i < subjects.Count; i++)
                    Console.WriteLine($"  {i + 1}. {subjects[i]}");
        }

        static void RemoveDb()
        {
            Console.Write("Enter Subject Name to remove: ");
            string subjectName = Console.ReadLine();
            bool removed = added.RemoveSubjectFromDb(subjectName);
            Console.WriteLine(removed ? $"Removed '{subjectName}' from DB." : $"'{subjectName}' not found in DB.");
        }
    }
}