using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SSM_MODEL;

namespace SSM_DL
{
    public class DL_SSM
    {
        private List<MODEL_SSM> subjects = new List<MODEL_SSM>();
        private int maxSubjects = 5;

        public bool Add(string subjectName, string schedule)
        {
            if (subjects.Count >= maxSubjects)
            {
                Console.WriteLine("Subject List is Full");
                return false;
            }

            subjects.Add(new MODEL_SSM(subjectName, schedule));
            return true;
        }

        public List<MODEL_SSM> GetSubjects() => subjects;

        public void ShowSubjects()
        {
            if (subjects.Count == 0)
            {
                Console.WriteLine("No subjects added yet.");
                return;
            }

            for (int i = 0; i < subjects.Count; i++)
                Console.WriteLine($"{i + 1}. {subjects[i]}");
        }

        public bool Remove(int subjectIndex)
        {
            if (subjectIndex < 0 || subjectIndex >= subjects.Count)
                return false;

            subjects.RemoveAt(subjectIndex);
            return true;
        }

        public void SaveToJson(string filePath)
        {
            JsonHandler.Save(filePath, subjects);
        }

        public void LoadFromJson(string filePath)
        {
            subjects = JsonHandler.Load(filePath);
        }

        public void SaveToSql(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var subject in subjects)
                {
                    string query = "INSERT INTO Subjects (SubjectName, Schedule) VALUES (@name, @schedule)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                        cmd.Parameters.AddWithValue("@schedule", subject.Schedule);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void LoadFromSql(string connectionString)
        {
            subjects.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SubjectName, Schedule FROM Subjects";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string schedule = reader.GetString(1);
                        subjects.Add(new MODEL_SSM(name, schedule));
                    }
                }
            }
        }
    }
}

