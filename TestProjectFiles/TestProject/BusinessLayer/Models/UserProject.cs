using System;
using System.Collections.Generic;

namespace BusinessLayer.Models
{
	public class UserProject
	{
		public int UserId { get; set; }
		public int ProjectId { get; set; }
		public bool IsActive { get; set; }
		public DateTime AssignedDate { get; set; }
	}
}
