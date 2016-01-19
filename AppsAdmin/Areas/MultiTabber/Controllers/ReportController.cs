using AppService.Areas.MultiTabber.Models;
using AppService.Areas.MultiTabber.Repository;
using AppService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppService.Areas.MultiTabber.Controllers
{
    public class ReportController : Controller
    {
        public IDashRepository dashDataContext = null;
        public IMultiTabberRepository dataContext = null;

        public ReportController()
        {
            dashDataContext = new DashRepository();
            dataContext = new MultiTabberRepository();
        }
        //
        // GET: /MultiTabber/Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getMData(string from,string to)
        {
            DataTableModel model = new DataTableModel();
            model.DateRange = from + " - " + to;
            model.TableName = "MultiTabber User Data";
            model.MData = (List<MData>)dataContext.getUserData(from, to,0);

            return View(model);
        }

        public ActionResult getEData(string from,string to)
        {
            ErrorDataTableModel model = new ErrorDataTableModel();
            model.DateRange = from + " - " + to;
            model.TableName = "MultiTabber Error Data";
            model.errData = (List<EData>)dataContext.getErrData(from, to);

            return View(model);
        }
    }
}
