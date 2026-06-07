using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using SSM_MODEL;

namespace SSM_DL
{
    public class DL_SSM
    {
        private const string FILE_PATH = "subjects.json";
        private static List<MODEL_SSM> subjects = new List<MODEL_SSM>();

        public void Add(string subjectName, string schedule)
        {
            subjects.Add(new MODEL_SSM { SubjectName = subjectName, Schedule = schedule });
            SaveToJson(FILE_PATH);
        }

        public bool Remove(int index)
        {
            if (index >= 0 && index < subjects.Count)
            {
                subjects.RemoveAt(index);
                SaveToJson(FILE_PATH);
                return true;
            }
            return false;
        }

        public List<MODEL_SSM> GetSubjects()
        {
            LoadFromJson(FILE_PATH);
            return subjects;
        }

        public void SaveToJson(string filePath)
        {
            string json = JsonSerializer.Serialize(subjects);
            File.WriteAllText(filePath, json);
        }

        public void LoadFromJson(string filePath)
        {
            if (!File.Exists(filePath)) return;
            string json = File.ReadAllText(filePath);
            subjects = JsonSerializer.Deserialize<List<MODEL_SSM>>(json)
                       ?? new List<MODEL_SSM>();
        }
    }
}