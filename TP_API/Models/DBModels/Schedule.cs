using System;
using System.ComponentModel.DataAnnotations;

namespace TP_API.Models.DBModels
{
    public class Schedule
    {
		[Key]
		public long ScheduleId { get; set; }
		public long TestId { get; set; }
        public string TestName { get; set; }
        public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public long CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public long UpdatedBy { get; set; }
		public DateTime UpdatedOn { get; set; }
		public bool IsActive { get; set; }
	}
}
