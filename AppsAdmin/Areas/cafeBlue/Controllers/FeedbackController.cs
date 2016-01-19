using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppService.Areas.cafeBlue.Controllers
{
    public class FeedbackController : Controller
    {
        //
        // GET: /cafeBlue/Feedback/

        public ActionResult Index()
        {
            return View();
        }

    }
}
