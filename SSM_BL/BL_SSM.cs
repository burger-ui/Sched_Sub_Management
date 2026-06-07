using SSM_DL;
using SSM_MODEL;
using System.Collections.Generic;

namespace SSM_BL
{
    public class AddSubBL
    {
        private DL_SSM addSubject = new DL_SSM();
        private SubSchedDBData dbHandler = new SubSchedDBData();

        public void AddSubject(string subjectName, string schedule) => addSubject.Add(subjectName, schedule);
        public bool RemoveSubject(int subjectIndex) => addSubject.Remove(subjectIndex);
        public void SaveDataToJson(string filePath) => addSubject.SaveToJson(filePath);
        public void LoadDataFromJson(string filePath) => addSubject.LoadFromJson(filePath);
        public List<MODEL_SSM> GetSubjectsFromMemory() => addSubject.GetSubjects();


        public void AddSubjectToDb(string subjectName, string schedule) => dbHandler.Add(new MODEL_SSM(subjectName, schedule));
        public bool RemoveSubjectFromDb(string subjectName) => dbHandler.Remove(subjectName);
        public List<MODEL_SSM> GetSubjectsFromDb() => dbHandler.GetAll();

        public bool UpdateSubjectInDb(string subjectName, string newSchedule)
        {
            var subjects = dbHandler.GetAll();
            var subject = subjects.Find(s => s.SubjectName.Equals(subjectName,
                          StringComparison.OrdinalIgnoreCase));
            if (subject == null) return false;

            dbHandler.Remove(subject.SubjectName);
            dbHandler.Add(new MODEL_SSM(subject.SubjectName, newSchedule));
            return true;
        }
    }
}

