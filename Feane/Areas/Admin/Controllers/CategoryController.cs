using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #region Index
        public IActionResult Index()
        {
            List<Category> categories = categoryService.GetCategories();
            return View(categories);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(CategoryModel model)
        {
            #region Existed
            bool result = categoryService.GetCategories().Any(x => x.CategoryName == model.CategoryName);
            if (result)
            {
                ModelState.AddModelError("CategoryName", "This Category is already existed");
                return View();
            }
            #endregion

            Category category = new Category
            {
                Id = model.Id,
                CategoryName = model.CategoryName
            };

            categoryService.Add(category);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            var dbcategory = categoryService.GetCategory(id);
            if (dbcategory == null) return BadRequest();

            CategoryModel dbmodel = new CategoryModel
            {
                Id = dbcategory.Id,
                CategoryName = dbcategory.CategoryName
            };

            return View(dbmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,CategoryModel model)
        {
            #region Get
            var dbcategory = categoryService.GetCategory(id);
            if (dbcategory == null) return BadRequest();

            CategoryModel dbmodel = new CategoryModel
            {
                Id = dbcategory.Id,
                CategoryName = dbcategory.CategoryName
            };
            #endregion

            #region Existed
            bool result = categoryService.GetCategories().Any(x => x.CategoryName == model.CategoryName && x.Id !=id);
            if (result)
            {
                ModelState.AddModelError("CategoryName", "This Category is already existed");
                return View();
            }
            #endregion

            dbmodel.Id = model.Id;
            dbmodel.CategoryName = model.CategoryName;

            Category category = new Category
            {
                Id = model.Id,
                CategoryName = model.CategoryName
            };

            categoryService.Update(category);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            categoryService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
