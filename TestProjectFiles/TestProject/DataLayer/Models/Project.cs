using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
	public class Project
	{

		public int ID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int Credits { get; set; }

		public virtual ICollection<UserProject> UserProjects { get; set; }
	}
}
