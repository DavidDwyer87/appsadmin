using AppService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppService.Repository
{
    public class DashDataContext:DbContext
    {
        public DashDataContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<project_tbl> projtbl { get; set; }
        public DbSet<projectStatus> project_status { get; set; }
    }

    public class DashRepository:IDashRepository
    {
        public DashRepository()            
        {

        }

        /// <summary>
        /// add new project
        /// </summary>
        /// <param name="project_name"></param>
        public void newProject(string project_name)
        {
            try
            {
                DashDataContext ctx = new DashDataContext();
                ctx.project_status.Add(new projectStatus
                {
                    project = project_name,
                    status = true
                });
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
            }            
        }
            

        /// <summary>
        /// get all the porjects and summary information
        /// </summary>
        /// <returns></returns>
        public List<ProjectModel> project_summary()
        {           
            List<ProjectModel> model = new List<ProjectModel>();
            
           try
           {
               DashDataContext ctx = new DashDataContext();
               int num = 1;
               foreach (projectStatus s in ctx.project_status)
               {                   
                   ProjectModel data = new ProjectModel
                   {
                       Id = num++,
                       Name = s.project,
                       Status = s.status,
                       Page_Count = new DashDataContext().projtbl.Where(m=>m.proj==s.project).Count()
                   };

                   model.Add(data);
               }
           }
           catch(Exception ex)
           {

           }

           return model;
        }

        /// <summary>
        /// get list and status of all the pages in the project
        /// </summary>
        /// <param name="project_name"></param>
        /// <returns></returns>
        public List<ManageProjectModel> projectSearch(string project_name)
        {
            List<ManageProjectModel> model = new List<ManageProjectModel>();

            try
            {
                DashDataContext ctx = new DashDataContext();
                var data = ctx.projtbl.Where(m => m.proj == project_name);

                int num = 1;
                foreach(project_tbl m in data)
                {
                    model.Add(new ManageProjectModel { 
                        Id = num++,
                        Page = m.url,
                        Status = m.PageActive
                    });
                }
            }
            catch(Exception ex)
            {

            }

            return model;
        }

        /// <summary>
        /// update project status
        /// </summary>
        /// <param name="project"></param>
        /// <param name="status"></param>
        public void updateProject_status(string project,bool status)
        {
            try
            {
                DashDataContext ctx = new DashDataContext();
                var prj = ctx.project_status.FirstOrDefault(m => m.project == project);
                prj.status = status;
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// update page status
        /// </summary>
        /// <param name="project"></param>
        /// <param name="page"></param>
        /// <param name="status"></param>
        public void updatePage_status(string project, string page,bool status)
        {
            try
            {
                DashDataContext ctx = new DashDataContext();
                var Page = ctx.projtbl.FirstOrDefault(m => m.proj == project && m.url == page);

                if (Page == null)
                    ctx.projtbl.Add(new project_tbl { 
                        PageActive = status,
                        proj = project,
                        url = page
                    });
                else
                    Page.PageActive = status;

                ctx.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// update page page name
        /// </summary>
        /// <param name="project"></param>
        /// <param name="currentPageName"></param>
        /// <param name="previousPageName"></param>
        public void updatePage_name(string project, string currentPageName, string previousPageName)
        {
            try
            {
                DashDataContext ctx = new DashDataContext();
                var data = ctx.projtbl.FirstOrDefault(m => m.proj == project && m.url == previousPageName);

                data.url = currentPageName;
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public void setName(string _name)
        {
            name = _name;
        }

        public string getName()
        {
            return name;
        }       

        public string name { get; set; }

        /// <summary>
        /// delete projects
        /// </summary>
        /// <param name="project_name"></param>
        public void deleteProject(string Project)
        {
            try
            {
                DashDataContext ctx = new DashDataContext();
                var data = ctx.project_status.FirstOrDefault(m => m.project == Project);

                if (data != null)
                    ctx.project_status.Remove(data);

                var data2 = ctx.projtbl.Where(m => m.proj == Project);

                if (data2 != null)
                    foreach (project_tbl m in data2)
                        ctx.projtbl.Remove(m);

                ctx.SaveChanges();

            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// delete page from project
        /// </summary>
        /// <param name="project_name"></param>
        /// <param name="page"></param>
        public void deletePage(string project_name, string page)
        {
            try
            {
                DashDataContext ctx = new DashDataContext();
                var data = ctx.projtbl.FirstOrDefault(m => m.proj == project_name && m.url == page);

                if (data != null)
                    ctx.projtbl.Remove(data);

                ctx.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// number ofpage for each project
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        public int pageCount(string Project)
        {
            int num = 0;
            try
            {
                num = new DashDataContext().projtbl.Where(m => m.proj == Project).Count();
            }
            catch (Exception ex) { }

            return num;
        }


        public ProjectMenuModel menuItems()
        {
            ProjectMenuModel menu = new ProjectMenuModel();
            menu.pages = new Dictionary<string, List<string>>();
            try
            {
                DashDataContext ctx = new DashDataContext();
                var projects = ctx.project_status.Where(m => m.status == true);

                foreach(projectStatus m in projects)
                    menu.pages.Add(m.project, new List<string>());

                foreach(string k in menu.pages.Keys)
                {
                    var data = ctx.projtbl.Where(j => j.proj == k && j.PageActive == true);
                    foreach (project_tbl n in data)
                        menu.pages[k].Add(n.url);
                }
                
                
            }
            catch (Exception ex) { }

            return menu;
        }
    }
}