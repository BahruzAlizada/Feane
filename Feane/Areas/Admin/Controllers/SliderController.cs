using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
		private readonly ISliderService sliderService;
		private readonly IWebHostEnvironment env;
        public SliderController(ISliderService sliderService,IWebHostEnvironment env)
        {
            this.sliderService = sliderService;
			this.env = env;
        }

		#region Index
		public IActionResult Index()
		{
			List<Slider> sliders = sliderService.GetSliders().OrderByDescending(x=>x.Id).ToList();
			return View(sliders);
		}
		#endregion

		#region Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Create(SliderModel model)
		{
			#region Existed
			bool result = sliderService.GetSliders().Any(x => x.Title == model.Title);
			if(result)
			{
				ModelState.AddModelError("Title", "This Slider is already existed");
				return View();
			}
            #endregion

       
            Slider slider = new Slider
			{
				Id = model.Id,
				Title = model.Title,
				Description = model.Description,
				IsDeactive = false
			};

            #region Photo
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
                ModelState.AddModelError("Photo", "Max 256Kb");
                return View();
            }
            string folder = Path.Combine(env.WebRootPath, "images", "slider");
            slider.Image = await model.Photo.SaveFileAsync(folder);
            #endregion

            sliderService.Add(slider);
			return RedirectToAction("Index");
		}
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            Slider dbslider = sliderService.GetSlider(id);
            if (dbslider == null)
                return BadRequest();

            SliderModel dbmodel = new SliderModel
            {
                Id = id,
                Title = dbslider.Title,
                Description = dbslider.Description
            };

            return View(dbmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id,SliderModel model)
        {
            Slider dbslider = sliderService.GetSlider(id);
            if (dbslider == null)
                return BadRequest();

            #region Existed
            bool result = sliderService.GetSliders().Any(x => x.Title == model.Title && x.Id != id);
            if (result)
            {
                ModelState.AddModelError("Title", "This Slider is already existed");
                return View();
            }
            #endregion

            Slider slider = new Slider();

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
                string folder = Path.Combine(env.WebRootPath, "images", "slider");
                slider.Image = await model.Photo.SaveFileAsync(folder);
                string path = Path.Combine(env.WebRootPath, folder, dbslider.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                dbslider.Image = slider.Image;
            }
            #endregion

            dbslider.Id = model.Id;
            dbslider.Title=model.Title;
            dbslider.Description = model.Description;
            

            model.Id = slider.Id;
            model.Title = slider.Title;
            model.Description = slider.Description;
            slider.IsDeactive = false;

            sliderService.Update(slider);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
		{
			sliderService.Activity(id);
			return RedirectToAction("Index");
		}
		#endregion
	}
}
