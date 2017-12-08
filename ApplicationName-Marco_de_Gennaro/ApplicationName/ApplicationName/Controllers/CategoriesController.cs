using ApplicationName.Classes;
using ApplicationName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationNameMongoDB = ApplicationName.Classes.MongoDB;

namespace ApplicationName.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult IndexCategories()
        {
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            var categories = db.GetAllCategories();
            CategoriesModel model = new CategoriesModel();
            model.EntityList = categories.ToList();
            return View(model);
        }

        public ActionResult AddCategory()
        {
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            var categories = db.GetAllCategories();
            CategoriesModel model = new CategoriesModel();
            model.EntityList = categories.ToList();
            ViewBag.Categories = model;
            return View();
        }

        public ActionResult EditCategory(string name)
        {
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            var category = db.GetCategoryByName(name);
            Category model = new Category();
            model.Name = category.Name;
            model.ID = category.ID;
            return View(model);
        }

        public ActionResult DeleteCategory(string name, string id)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id))
            {
                throw new MissingFieldException("invalid parameters");
            }
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            bool result = db.RemoveCategoryById(id);
            return RedirectToAction("IndexCategories", new { result = result });
        }

        public ActionResult SaveCategory(string name, string id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                TempData["ErrorMessage"] = "name cannot be null";
                return RedirectToAction("IndexCategories", "Categories");
            }
            bool result;
            ApplicationNameMongoDB db = new ApplicationNameMongoDB();
            Category category = db.GetCategoryByName(name);
            if (category != null)
            {
                TempData["ErrorMessage"] = $"name {name} already exists";
                return RedirectToAction("IndexCategories", "Categories");
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                result = db.InsertCategory(new Category
                {
                    Name = name
                });
                return RedirectToAction("IndexCategories", new { result = result });
            }
            else
            {
                result = db.UpdateCategory(new Category
                {
                    ID = id,
                    Name = name
                });
                return RedirectToAction("IndexCategories", new { result = result });
            }
        }
    }
}