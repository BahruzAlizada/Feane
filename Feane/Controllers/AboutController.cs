using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;
        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }
        public IActionResult Index()
        {
            About about = aboutService.GetAbout();
            return View(about);
        }
    }
}
