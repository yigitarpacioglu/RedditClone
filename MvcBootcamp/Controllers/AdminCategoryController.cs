using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcBootcamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        private CategoryManager manager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var categoryModel = manager.GetList();
            return View(categoryModel);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(category);
            if (result.IsValid)
            {
                manager.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {   
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View();
        }
    }
}