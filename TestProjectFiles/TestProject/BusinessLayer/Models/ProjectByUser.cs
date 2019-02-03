using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
	public class ProjectByUser
	{
		public int ProjectId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime AssignedDay { get; set; }
		public DateTime EndDate { get; set; }
		public string TimeToStart { get; set; }
		public int Credits { get; set; }
		public string Status { get; set; }
	}
}
