using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        #region Index
        public IActionResult Index()
        {
            List<Testimonial> testimonials = testimonialService.GetTestimonials().OrderByDescending(x=>x.Id).ToList();
            return View(testimonials);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(TestimonialModel model)
        {
            Testimonial testimonial = new Testimonial
            {
                Id = model.Id,
                FullName = model.FullName,
                Description = model.Description,
                IsDeactive = false
            };

            testimonialService.Add(testimonial);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            var dbtestimonial = testimonialService.GetTestimonial(id);
            if (dbtestimonial == null) return BadRequest();

            TestimonialModel dbmodel = new TestimonialModel
            {
                Id = dbtestimonial.Id,
                FullName = dbtestimonial.FullName,
                Description = dbtestimonial.Description,
            };

            return View(dbmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,TestimonialModel model)
        {
            var dbtestimonial = testimonialService.GetTestimonial(id);
            if (dbtestimonial == null) return BadRequest();

            TestimonialModel dbmodel = new TestimonialModel
            {
                Id = dbtestimonial.Id,
                FullName = dbtestimonial.FullName,
                Description = dbtestimonial.Description,
            };

            

            dbmodel.Id = model.Id;
            dbmodel.FullName = model.FullName;
            dbmodel.Description = model.Description;

            Testimonial testimonial = new Testimonial
            {
                Id = model.Id,
                FullName = model.FullName,
                Description = model.Description,
                IsDeactive = false,
                Created = dbtestimonial.Created
            };
          

            testimonialService.Update(testimonial);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            testimonialService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
