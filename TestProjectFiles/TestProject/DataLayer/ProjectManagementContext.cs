
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataLayer.Models;

namespace DataLayer
{
	public class ProjectManagementContext : DbContext
	{
		public ProjectManagementContext() : base("ProjectManagementContext")
		{
		}

		public DbSet<User> User { get; set; }
		public DbSet<Project> Project { get; set; }
		public DbSet<UserProject> UserProject { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}

}
