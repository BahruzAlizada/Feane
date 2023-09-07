using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Feane.Models;
using Feane.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Feane.Controllers
{
	public class HomeController : Controller
	{
		private readonly ISliderService sliderService;
		private readonly ICategoryService categoryService;
		private readonly IMenuService menuService;

		public HomeController(ISliderService sliderService,ICategoryService categoryService,IMenuService menuService)
		{
			this.sliderService = sliderService;
			this.categoryService = categoryService;
			this.menuService = menuService;
		}

		public IActionResult Index()
		{
			HomeVM homeVM = new HomeVM
			{
				Sliders = sliderService.GetSliders().Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).Take(3).ToList(),
				Categories = categoryService.GetCategories().Where(x => !x.IsDeactive).ToList(),
				Menus = menuService.GetMenus().Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).ToList()
			};
            return View(homeVM);
		}

	

		public IActionResult Error()
		{
			return View();
		}
	}
}