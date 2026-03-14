using System;
using System.Collections.Generic;
using SSM_DL;

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

        public List<MODEL_SSM> GetSubjects()
        {
            return subjects;
        }
        public void ShowSubjects()
        {
            if (subjects.Count == 0)
            {
                Console.WriteLine("No subjects added yet.");
                return;
            }

            for (int i = 0; i < subjects.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {subjects[i]}");
            }
        }

        public bool Remove(int subjectIndex)
        {
            if (subjectIndex < 0 || subjectIndex >= subjects.Count)
            {
                return false;
            }

            subjects.RemoveAt(subjectIndex);
            return true;
        }
    }
}
