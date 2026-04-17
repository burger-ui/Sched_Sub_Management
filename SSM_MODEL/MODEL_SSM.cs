namespace SSM_MODEL
{
    public class MODEL_SSM
    {
        public string SubjectName { get; set; }
        public string Schedule { get; set; }

        public MODEL_SSM() { }

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
