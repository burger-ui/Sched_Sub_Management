using System;
using SSM_DL;

namespace SSM_BL
{
    public class AddSubBL
    {
        private DL_SSM addSubject = new DL_SSM();

        public void AddSubject(string subjectName, string schedule)
        {
            bool added = addSubject.Add(subjectName, schedule);

            if (added)
                Console.WriteLine("Subject added successfully.");
            else
                Console.WriteLine("Failed to add subject. Subject list may be full.");
        }

        public void ShowSubjects()
        {
            addSubject.ShowSubjects();
        }

        public void RemoveSubject(int subjectIndex)
        {
            bool removed = addSubject.Remove(subjectIndex);

            if (removed)
                Console.WriteLine("Subject removed successfully.");
            else
                Console.WriteLine("Failed to remove subject.");
        }

        public void SaveDataToJson(string filePath)
        {
            addSubject.SaveToJson(filePath);
            Console.WriteLine("Subjects saved to JSON file.");
        }

        public void LoadDataFromJson(string filePath)
        {
            addSubject.LoadFromJson(filePath);
            Console.WriteLine("Subjects loaded from JSON file.");
        }
    }
}
