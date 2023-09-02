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
        public SliderController(ISliderService sliderService)
        {
            this.sliderService = sliderService;
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

		public IActionResult Create(SliderModel model)
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
                Image = "1",
				Title = model.Title,
				Description = model.Description,
				IsDeactive = false
			};


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

        public IActionResult Update(int id,SliderModel model)
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

   
            dbslider.Id = model.Id;
            dbslider.Title=model.Title;
            dbslider.Description = model.Description;
            

            Slider slider = new Slider
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsDeactive = false,
                Image="1"
            };
           
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
