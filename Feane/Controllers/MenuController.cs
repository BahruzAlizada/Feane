using BusinessLayer.Abstract;
using Feane.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService menuService;
        private readonly ICategoryService categoryService;
        public MenuController(IMenuService menuService,ICategoryService categoryService)
        {
            this.menuService= menuService;
            this.categoryService= categoryService;
        }

        #region Index
        public IActionResult Index()
        {
            MenuVM menuVM = new MenuVM
            {
                Categories = categoryService.GetCategories().Where(x => !x.IsDeactive).ToList(),
                Menus = menuService.GetMenus().Where(x => !x.IsDeactive).OrderByDescending(x=>x.Id).ToList()
            };

            return View(menuVM);
        }
        #endregion
    }
}
