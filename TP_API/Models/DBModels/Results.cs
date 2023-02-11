using System;
using System.ComponentModel.DataAnnotations;

namespace TP_API.Models.DBModels
{
    public class Results
    {
		[Key]
		public long RId { get; set; }
		public long CId { get; set; }
		public long ScheduleId { get; set; }
		public long TestId { get; set; }
		public long QId { get; set; }
		public long AnsId { get; set; }
		public long CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
