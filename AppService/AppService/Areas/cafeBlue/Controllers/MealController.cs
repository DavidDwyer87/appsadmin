using AppService.Areas.cafeBlue.Models;
using CafeBlue;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace AppService.Areas.cafeBlue.Controllers
{
    public class MealController : Controller
    {
        //
        // GET: /cafeBlue/Meal/

        public ActionResult Index()
        {
            ProductModel model = new ProductModel();   
            return View(model.getProduct("meal"));
        }

        [HttpPost]
        public ActionResult FileUpload(ProductsTable model,HttpPostedFileBase file)
        {         
            if (file!= null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Areas/cafeBlue/Images/"), fileName);
                file.SaveAs(path);
            }
          
            if(file != null)
                model.ProductImage = System.IO.Path.GetFileName(file.FileName);

            ProductModel pmodel = new ProductModel();
            pmodel.newProduct(model);

            return RedirectToAction("Index",model.ProductCatigory);
        }

        public JsonResult ManageProduct(string productName,string cati)
        {
            return Json(new ProductModel().findProduct(cati,productName), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateProduct(ProductsTable data)
        {
            new ProductModel().editProduct(data);           
            return Json(null);
        }

        [HttpPost]
        public JsonResult NameStatus(string name,string cati)
        {
            bool state = false;
            state = ProductModel.nameExist(name,cati);
            return Json(state);
        }

        [HttpPost]
        public JsonResult RemoveProd(string name,string cati)
        {
            string done = "done";
            ProductModel meal = new ProductModel();
            meal.removeProduct(name, cati);
            return Json(done);
        }
    }    
}
