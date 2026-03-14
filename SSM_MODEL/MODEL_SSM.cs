namespace SSM_DL
{
    public class MODEL_SSM
    {
        public string SubjectName { get; set; }
        public string Schedule { get; set; }

        public MODEL_SSM(string subjectName, string schedule)
        {
            SubjectName = subjectName;
            Schedule = schedule;
        }


        public override string ToString()
        {
            return $"{SubjectName} - {Schedule}";
        }
    }
}