using SSM_DL;
using SSM_MODEL;
using System;

namespace SSM_BL
{
    public class AddSubBL
    {
        private DL_SSM addSubject = new DL_SSM(); 
        private SubSchedDBData dbHandler = new SubSchedDBData(); 

        public void AddSubject(string subjectName, string schedule)
        {
            bool added = addSubject.Add(subjectName, schedule);
            Console.WriteLine(added ? "Subject added successfully." : "Failed to add subject. Subject list may be full.");
        }

        public void ShowSubjects() => addSubject.ShowSubjects();

        public void RemoveSubject(int subjectIndex)
        {
            bool removed = addSubject.Remove(subjectIndex);
            Console.WriteLine(removed ? "Subject removed successfully." : "Failed to remove subject.");
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

        public void AddSubjectToDb(string subjectName, string schedule)
        {
            dbHandler.Add(new MODEL_SSM(subjectName, schedule));
            Console.WriteLine("Subject added to DB.");
        }

        public void ShowSubjectsFromDb()
        {
            var subjects = dbHandler.GetAll();
            if (subjects.Count == 0) Console.WriteLine("No subjects in DB.");
            else foreach (var s in subjects) Console.WriteLine(s);
        }

        public void RemoveSubjectFromDb(string subjectName)
        {
            bool removed = dbHandler.Remove(subjectName);
            Console.WriteLine(removed ? "Subject removed from DB." : "Failed to remove subject from DB.");
        }
    }
}
