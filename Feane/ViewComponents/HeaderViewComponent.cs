using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Feane.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IBioService bioService;
        public HeaderViewComponent(IBioService bioService)
        {
            this.bioService = bioService;
        }
        public IViewComponentResult Invoke()
        {
            var bio = bioService.GetBio();
            return View(bio);
        }
    }
}
