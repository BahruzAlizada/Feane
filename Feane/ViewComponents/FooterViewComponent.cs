using BusinessLayer.Abstract;
using Feane.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feane.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IBioService bioService;
        private readonly ISocialMediaService socialMediaService;
        public FooterViewComponent(IBioService bioService,ISocialMediaService socialMediaService)
        {
            this.bioService = bioService;
            this.socialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            FooterVM footer = new FooterVM
            {
                Bio = bioService.GetBio(),
                SocialMedia = socialMediaService.GetSocialMedia()
            };

            return View(footer);
        }
    }
}
