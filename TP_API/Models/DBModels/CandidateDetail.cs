using System;
using System.ComponentModel.DataAnnotations;

namespace TP_API.Models.DBModels
{
    public class CandidateDetail
    {
		[Key]
		public long CId { get; set; }
		public long ScheduleId { get; set; }
		public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public long CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public long UpdatedBy { get; set; }
		public DateTime UpdatedON { get; set; }
		public bool IsActive { get; set; }
	}
}
