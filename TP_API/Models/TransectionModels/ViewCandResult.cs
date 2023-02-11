using System;

namespace TP_API.Models.TransectionModels
{
    public class ViewCandResult
    {
        public int CorrectCount { get; set; }
        public int IncorrectCount { get; set; }
        public int Points { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TestName { get; set; }
    }
}
