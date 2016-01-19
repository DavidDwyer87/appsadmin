using AppService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppService.Repository
{
    public interface IDashRepository
    {
        void newProject(string project_name);
        void deletePage(string project_name,string page);
        List<ProjectModel> project_summary();
        List<ManageProjectModel> projectSearch(string project_name);
        void updateProject_status(string project,bool status);
        void updatePage_status(string project, string page,bool status);
        void updatePage_name(string project, string currentPageName, string previousPageName);
        void setName(string name);
        string getName();
        void deleteProject(string Project);
        //int pageCount(string Project);
        ProjectMenuModel menuItems();
    }
}
