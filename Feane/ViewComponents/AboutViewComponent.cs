using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Feane.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutService aboutService;
        public AboutViewComponent(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        public  IViewComponentResult Invoke()
        {
            About about = aboutService.GetAbout(); 
            return View(about);
        }
    }
}
