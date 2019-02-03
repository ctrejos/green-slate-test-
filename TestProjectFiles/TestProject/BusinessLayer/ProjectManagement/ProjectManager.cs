using System;
using System.Collections.Generic;
using BusinessLayer.Models;
using BusinessLayer.ProjectManagement;
using DataLayer;
using System.Linq;

namespace BusinessLayer.ProjectManagement
{
	
	public class ProjectManager : IProjectManager
	{
		ProjectManagementContext context = new ProjectManagementContext(); 
		public List<User> GetUserList()
		{
			var userList = context.User.ToList();
			return CastUserToBusinessLayer(userList);
		}

		public List<ProjectByUser> GetProjectsByUserId(int userId)
		{
			//var projecUsertList = CastUserProjectToBusiness((from up in context.UserProject where up.UserId == userId select up).ToList());
			//var projecUsertIdList = (from up in projecUsertList where up.UserId == userId select up.ProjectId).ToList();
			//var projectList = CastProjectToBusinessLayer((from p in context.Project where projecUsertIdList.Contains(p.ID) select p).ToList());
			var projectByUser = (from proj in context.Project
								join up in context.UserProject on proj.ID equals up.ProjectId
				where up.UserId == userId
								 select new { Project = proj, UserProject = up }).ToList();
			var projectDescriptionList = new List<ProjectByUser>();
			foreach (var project in projectByUser)
			{
				ProjectByUser newProjectByUser = new ProjectByUser();
				newProjectByUser.ProjectId = project.Project.ID;
				newProjectByUser.StartDate = project.Project.StartDate;
				newProjectByUser.AssignedDay = project.UserProject.AssignedDate;
				newProjectByUser.EndDate = project.Project.EndDate;
				newProjectByUser.TimeToStart = (project.Project.StartDate - project.UserProject.AssignedDate).TotalDays < 0 ? "Started" : (project.Project.StartDate - project.UserProject.AssignedDate).TotalDays.ToString();
				newProjectByUser.Credits = project.Project.Credits;
				newProjectByUser.Status = project.UserProject.IsActive ? "Active" : "Inactive";

				projectDescriptionList.Add(newProjectByUser);
			}
			return projectDescriptionList;
		}
		

		public List<UserProject> CastUserProjectToBusiness(List<DataLayer.Models.UserProject> userProjectList)
		{
			return (from u in userProjectList
					select new UserProject()
				{
					UserId = u.UserId,
					ProjectId = u.ProjectId,
					IsActive = u.IsActive,
					AssignedDate = u.AssignedDate
				}).ToList();

		}

		public List<User> CastUserToBusinessLayer(List<DataLayer.Models.User> userList)
		{
			return (from u in userList
				select new User()
			{
				ID = u.ID,
				FirstName = u.FirstName,
				LastName = u.LastName,
			}).ToList();

		}

		public List<Project> CastProjectToBusinessLayer(List<DataLayer.Models.Project> projectList)
		{
			return (from u in projectList
				select new Project()
				{
					ID = u.ID,
					Credits = u.Credits,
					EndDate = u.EndDate,
					StartDate = u.StartDate
				}).ToList();

		}

		public List<int> CastUserProjectToId(List<DataLayer.Models.UserProject> projectList)
		{
			return (from u in projectList
					select u.ProjectId).ToList();

		}
	}
}
