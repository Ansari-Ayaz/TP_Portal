using System;
using System.ComponentModel.DataAnnotations;

namespace TP_API.Models.DBModels
{
    public class FResult
    {
        [Key]
        public long FR_Id { get; set; }
        public long TestId { get; set; }
        public long ScheduleId { get; set; }
        public long CId { get; set; }
        public int CorrectCount { get; set; }
        public int IncorrectCount { get; set; }
        public int Points { get; set; }
        public DateTime SubmissionDate { get; set; }

    }
}
