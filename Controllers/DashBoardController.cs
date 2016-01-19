using AppService.Models;
using AppService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppService.Controllers
{

    public class DashBoardController : Controller
    {

        public IDashRepository dashDataContext = null;
        public static string username { get; set; }
        public static ProjectMenuModel menu { get; set; }
        //
        // GET: /DashBoard/
        public DashBoardController()
        {
            try
            {
                dashDataContext = new DashRepository();

                menu = dashDataContext.menuItems();
            }
            catch(Exception ex)
            {

            }
        }

        public ActionResult Index()
        {
            if(TempData.Count>0)
                username = TempData["name"].ToString();

            return View();
        }

        public ActionResult proj()
        {
            menu = dashDataContext.menuItems();
            return View(dashDataContext.project_summary());
        }

        [HttpPost]
        public ActionResult newProj(string projectName)
        {
            if (!string.IsNullOrEmpty(projectName))
            {
                dashDataContext.newProject(projectName);
            }
            return RedirectToAction("proj");
        }

        public ActionResult getPages(string project)
        {            
            IEnumerable<ManageProjectModel> exist = dashDataContext.projectSearch(project);
            return View(exist);
        }

        public ActionResult updateStatus(string name, string page, string s_project, string s_page)
        {
            
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(page)) //update page status
            {    
                bool state = false;

                if (s_page == "online")
                    state = true;

                dashDataContext.updatePage_status(name, page, state);
            }
            else if (string.IsNullOrEmpty(page)) //update project status
            {
                bool state = false;

                if (s_project == "online")
                    state = true;

                dashDataContext.updateProject_status(name,state);
            }
            return Json(null);
        }

        public ActionResult edit(string project, string current, string previous)
        {
            dashDataContext.updatePage_name(project, current, previous);
            return Json(null);
        }

        public ActionResult removePage(string project, string page)
        {
            dashDataContext.deletePage(project, page);
            return Json(null);
        }
       
        public ActionResult deleteProject(string project)
        {
            dashDataContext.deleteProject(project);
            return Json(null);
        }
    }
}
