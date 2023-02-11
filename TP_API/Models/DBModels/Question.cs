using System;
using System.ComponentModel.DataAnnotations;

namespace TP_API.Models.DBModels
{
    public class Question
    {
		[Key]
		public long? QId { get; set; }
		public long TestId { get; set; }
		public string QuestionText { get; set; }
		public long CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public long UpdatedBy { get; set; }
		public DateTime UpdatedOn { get; set; }
		public bool IsActive { get; set; }
	}
}
