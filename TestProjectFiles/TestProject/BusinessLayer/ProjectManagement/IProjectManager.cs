using System.Collections.Generic;
using BusinessLayer.Models;

namespace BusinessLayer.ProjectManagement
{
	public interface IProjectManager
	{
		List<User> GetUserList();
		List<ProjectByUser> GetProjectsByUserId(int userId);
	}
}