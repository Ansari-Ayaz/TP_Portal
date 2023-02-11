using System;

namespace TP_UI2.Models
{
    public class User
    {
		
		public long UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Role { get; set; }
		public bool IsActive { get; set; }
		public long CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public long UpdatedBy { get; set; }
		public DateTime UpdatedOn { get; set; }
	}
}
