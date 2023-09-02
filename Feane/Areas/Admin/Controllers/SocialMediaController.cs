using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService socialMediaService;
        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            this.socialMediaService = socialMediaService;
        }

        #region Index
        public IActionResult Index()
        {
            SocialMedia socialMedia = socialMediaService.GetSocialMedia();
            return View(socialMedia);
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            SocialMedia dbsocial = socialMediaService.GetSocialMediaId(id);
            if (dbsocial == null) return BadRequest();

            SocialMediaModel dbmodel = new SocialMediaModel
            {
                Id = dbsocial.Id,
                TvitterLink = dbsocial.TvitterLink,
                InstagramLink = dbsocial.InstagramLink,
                FacebookLink = dbsocial.FacebookLink,
                LinkedinLink = dbsocial.LinkedinLink
            };

            return View(dbmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,SocialMediaModel model)
        {
            #region Get
            SocialMedia dbsocial = socialMediaService.GetSocialMediaId(id);
            if (dbsocial == null) return BadRequest();

            SocialMediaModel dbmodel = new SocialMediaModel
            {
                Id = dbsocial.Id,
                TvitterLink = dbsocial.TvitterLink,
                InstagramLink = dbsocial.InstagramLink,
                FacebookLink = dbsocial.FacebookLink,
                LinkedinLink = dbsocial.LinkedinLink
            };
            #endregion

            dbmodel.Id = model.Id;
            dbmodel.FacebookLink = model.FacebookLink;
            dbmodel.LinkedinLink = model.LinkedinLink;
            dbmodel.InstagramLink = model.InstagramLink;
            dbmodel.TvitterLink = model.TvitterLink;

            SocialMedia media = new SocialMedia
            {
                Id = model.Id,
                TvitterLink = model.TvitterLink,
                InstagramLink = model.InstagramLink,
                FacebookLink = model.FacebookLink,
                LinkedinLink = model.LinkedinLink
            };

            socialMediaService.Update(media);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
