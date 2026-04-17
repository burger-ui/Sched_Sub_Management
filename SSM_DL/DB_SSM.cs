using SSM_MODEL;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace SSM_DL
{
    public class SubSchedDBData
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=SSM_DB;Integrated Security=True;TrustServerCertificate=True";

        private SqlConnection sqlConnection;

        public SubSchedDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Add(MODEL_SSM subject)
        {
            var insertStatement = "INSERT INTO SubSched (SubjectName, Schedule) VALUES (@SubjectName, @Schedule)";
            using (SqlCommand cmd = new SqlCommand(insertStatement, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                cmd.Parameters.AddWithValue("@Schedule", subject.Schedule);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public List<MODEL_SSM> GetAll()
        {
            var subjects = new List<MODEL_SSM>();
            var selectStatement = "SELECT SubjectName, Schedule FROM SubSched";

            using (SqlCommand cmd = new SqlCommand(selectStatement, sqlConnection))
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    subjects.Add(new MODEL_SSM(
                        reader["SubjectName"].ToString(),
                        reader["Schedule"].ToString()
                    ));
                }

                sqlConnection.Close();
            }
            return subjects;
        }

        public bool Remove(string subjectName)
        {
            var deleteStatement = "DELETE FROM SubSched WHERE SubjectName = @SubjectName";
            using (SqlCommand cmd = new SqlCommand(deleteStatement, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@SubjectName", subjectName);

                sqlConnection.Open();
                int rows = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return rows > 0;
            }
        }
    }
}
