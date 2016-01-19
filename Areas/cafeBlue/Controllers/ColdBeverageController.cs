using AppService.Areas.cafeBlue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppService.Areas.cafeBlue.Controllers
{
    public class ColdBeverageController : Controller
    {
        //
        // GET: /cafeBlue/ColdBeverage/
        public ActionResult Index()
        {
            ProductModel model = new ProductModel();
            return View(model.getProduct("cold"));
        }

    }
}
