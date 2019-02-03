using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.ProjectManagement;

namespace TestProject.Controllers
{
	public class ProjectManagementController : Controller
	{
		ProjectManager pm = new ProjectManager();
		[HttpGet]
		public JsonResult GetUserList()
		{
			var userList = pm.GetUserList();
			return Json(new { userList }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetProjectByUserID(int userId)
		{
			var projectList = pm.GetProjectsByUserId(userId);
			return Json(new { projectList }, JsonRequestBehavior.AllowGet);
		}

	}
}