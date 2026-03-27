using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SSM_MODEL;

namespace SSM_DL
{
    public static class JsonHandler
    {
        public static void Save(string filePath, List<MODEL_SSM> subjects)
        {
            string json = JsonSerializer.Serialize(subjects);
            File.WriteAllText(filePath, json);
        }

        public static List<MODEL_SSM> Load(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<MODEL_SSM>>(json) ?? new List<MODEL_SSM>();
            }
            return new List<MODEL_SSM>();
        }
    }
}
