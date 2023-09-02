using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Feane.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly ITestimonialService testimonialService;
        public TestimonialViewComponent(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            List<Testimonial> testimonials = testimonialService.GetTestimonials().OrderByDescending(x => x.Id).Take(4).ToList();
            return View(testimonials);
        }
    }
}
