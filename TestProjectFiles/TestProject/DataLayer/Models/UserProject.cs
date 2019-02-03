using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
	public class UserProject
	{
		[Key, Column(Order = 0)]
		public int UserId { get; set; }
		[Key, Column(Order = 1)]
		public int ProjectId { get; set; }

		public bool IsActive { get; set; }
		public DateTime AssignedDate { get; set; }
	}
}
