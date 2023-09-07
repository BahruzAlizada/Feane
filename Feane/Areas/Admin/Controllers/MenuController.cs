using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly IMenuService menuService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment env;
        public MenuController(IMenuService menuService,ICategoryService categoryService, IWebHostEnvironment env)
        {
            this.menuService = menuService;
            this.categoryService = categoryService;
            this.env = env;
        }

        #region Index
        public IActionResult Index(int page=1)
        {
            decimal take = 8;
            ViewBag.PageCount = Math.Ceiling(menuService.GetMenus().Count() / take);
            ViewBag.CurrentPage=page;

            List<Menu> menus = menuService.GetMenus().OrderByDescending(x => x.Id).Skip((page - 1) * (int)take).Take((int)take).ToList();
            return View(menus);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.Categories = categoryService.GetCategories().Where(x=>!x.IsDeactive).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(MenuModel model,int catId)
        {
            ViewBag.Categories = categoryService.GetCategories().Where(x => !x.IsDeactive).ToList();

            #region Existed
            bool result = menuService.GetMenus().Any(x => x.Name == model.Name);
            if(result)
            {
                ModelState.AddModelError("Name", "This Menu is alredy existed");
                return View();
            }
            #endregion

            #region Image
            if (model.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be null");
                return View();
            }
            if (!model.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Just Image type");
                return View();
            }
            if (model.Photo.IsOlder256Kb())
            {
                ModelState.AddModelError("Photo", "Max 256");
                return View();
            }
            string folder = Path.Combine(env.WebRootPath, "images", "menu");
            model.Image = await model.Photo.SaveFileAsync(folder);
            #endregion

            model.CategoryId = catId;

            Menu menu = new Menu
            {
                Id = model.Id,
                CategoryId = model.CategoryId,
                Name = model.Name,
                Description = model.Description,
                Image = model.Image,
                Price = model.Price,
                IsDeactive = false
            };

            menuService.Add(menu);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            ViewBag.Categories = categoryService.GetCategories().Where(x =>!x.IsDeactive).ToList();
            Menu dbmenu = menuService.GetMenu(id);
            if (dbmenu is null) return BadRequest();

            MenuModel dbmodel = new MenuModel
            {
                Id = dbmenu.Id,
                CategoryId = dbmenu.CategoryId,
                Name = dbmenu.Name,
                Description = dbmenu.Description,
                Image = dbmenu.Image,
                Price = dbmenu.Price,
            };

            return View(dbmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id,MenuModel model, int catId)
        {
            ViewBag.Categories = categoryService.GetCategories().Where(x => !x.IsDeactive).ToList();
            #region Get
            Menu dbmenu = menuService.GetMenu(id);
            if (dbmenu is null) return BadRequest();

            MenuModel dbmodel = new MenuModel
            {
                Id = dbmenu.Id,
                CategoryId = dbmenu.CategoryId,
                Name = dbmenu.Name,
                Description = dbmenu.Description,
                Image = dbmenu.Image,
                Price = dbmenu.Price,
            };
            #endregion

            #region Existed
            bool result = menuService.GetMenus().Any(x => x.Name == model.Name && x.Id != id);
            if (result)
            {
                ModelState.AddModelError("Name", "This Menu is alredy existed");
                return View();
            }
            #endregion

            #region Image
            if (model.Photo is not null)
            {
                if (!model.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Just Image type");
                    return View();
                }
                if (model.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Max 256Kb");
                    return View();
                }
                string folder = Path.Combine(env.WebRootPath, "images", "menu");
                model.Image = await model.Photo.SaveFileAsync(folder);
                string path = Path.Combine(env.WebRootPath, folder, dbmenu.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbmodel.Image = model.Image;
            }
            else
                model.Image = dbmenu.Image;
            #endregion

            model.CategoryId = catId;

            Menu menu = new Menu
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Image = model.Image,
                CategoryId = model.CategoryId,
                Description = model.Description,
                IsDeactive = false
            };

            menuService.Update(menu);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            menuService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
