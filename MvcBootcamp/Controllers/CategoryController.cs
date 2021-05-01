 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;

 namespace MvcBootcamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private CategoryManager manager = new CategoryManager();
        public ActionResult Index() 
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryModel= manager.GetAll();
            return View(categoryModel);

        }
    }
}