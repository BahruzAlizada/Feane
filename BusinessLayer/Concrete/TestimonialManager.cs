using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal testimonialDal;
        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            this.testimonialDal = testimonialDal;
        }

        public void Activity(int id)
        {
            testimonialDal.Activity(id);
        }

        public void Add(Testimonial testimonial)
        {
            testimonialDal.Add(testimonial);
        }

        public Testimonial GetTestimonial(int id)
        {
            return testimonialDal.Get(x=>x.Id==id);
        }

        public List<Testimonial> GetTestimonials()
        {
            return testimonialDal.GetAll();
        }

        public void Update(Testimonial testimonial)
        {
            testimonialDal.Update(testimonial);
        }
    }
}
