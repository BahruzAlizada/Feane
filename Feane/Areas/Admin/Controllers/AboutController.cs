using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;
        private readonly IWebHostEnvironment env;
        public AboutController(IAboutService aboutService,IWebHostEnvironment env)
        {
            this.aboutService = aboutService;
            this.env = env;
        }

        #region Index
        public IActionResult Index()
        {
            About about = aboutService.GetAbout();
            return View(about);
        }
        #endregion

    
        #region Update
        public IActionResult Update(int id)
        {
            About dbabout = aboutService.GetAboutId(id);

            AboutModel dbAbout = new AboutModel
            {
                Id = dbabout.Id,
                Title = dbabout.Title,
                Description = dbabout.Description,
                Image = dbabout.Image
            };

            return View(dbAbout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id,AboutModel model)
        {
            #region Get
            About dbabout = aboutService.GetAbout();

            AboutModel dbModel = new AboutModel
            {
                Id = dbabout.Id,
                Title = dbabout.Title,
                Description = dbabout.Description,
                Image = dbabout.Image
            };
            #endregion

            About about = new About();

            #region Image
            if (model.Photo != null)
            {
                if (!model.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Just Image Type");
                    return View();
                }
                if (model.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Max 256Kb");
                    return View();
                }
                string folder = Path.Combine(env.WebRootPath, "images", "about");
                model.Image = await model.Photo.SaveFileAsync(folder);
                string path = Path.Combine(env.WebRootPath, folder, dbabout.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbModel.Image = model.Image;
            }
            else
                model.Image = dbModel.Image;
            #endregion

            dbModel.Id = model.Id;
            dbModel.Title = model.Title;
            dbModel.Description = model.Description;
              

            about.Id = model.Id;
            about.Image = model.Image;
            about.Title = model.Title;
            about.Description = model.Description;
           

            aboutService.Update(about);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
