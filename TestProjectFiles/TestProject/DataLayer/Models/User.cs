using System.Collections.Generic;

namespace DataLayer.Models
{
	public class User
	{

		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public virtual ICollection<UserProject> UserProjects { get; set; }
	}
}
