using System;
using System.ComponentModel.DataAnnotations;

namespace TP_API.Models.DBModels
{
    public class Option
    {
		[Key]
		public long? OptId { get; set; }
		public long? QId { get; set; }
		public string OptionText { get; set; }
		public bool IsCorrect { get; set; }
		public long CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public long UpdatedBy { get; set; }
		public DateTime UpdatedOn { get; set; }
	}
}
