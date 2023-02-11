using System;
using System.ComponentModel.DataAnnotations;

namespace TP_UI2.Models
{
    public class TestDetail
    {
		
			[Key]
			public long TestId { get; set; }
			public string TestName { get; set; }
			public long OwnerId { get; set; }
			public int No_Of_Q { get; set; }
			public int PerQ_Point { get; set; }
			public int PerQ_Time_Min { get; set; }
			public long CreatedBy { get; set; }
			public DateTime CreatedOn { get; set; }
			public long UpdatedBy { get; set; }
			public DateTime UpdatedOn { get; set; }
			public bool IsActive { get; set; }
		
	}
}
