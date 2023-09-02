using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Feane.Controllers
{
	public class HomeController : Controller
	{
		private readonly ISliderService sliderService;

		public HomeController(ISliderService sliderService)
		{
			this.sliderService = sliderService;
		}

		public IActionResult Index()
		{
            List<Slider> sliders = sliderService.GetSliders().Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).Take(3).ToList();
            return View(sliders);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}