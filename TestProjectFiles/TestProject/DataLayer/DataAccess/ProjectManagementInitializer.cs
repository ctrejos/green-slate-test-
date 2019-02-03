using System;
using System.Collections.Generic;
using DataLayer.Models;

namespace DataLayer.DataAccess
{
	public class ProjectManagementInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProjectManagementContext>
	{
		protected override void Seed(ProjectManagementContext context)
		{
			context.SaveChanges();
			base.Seed(context);
		}
	}
}