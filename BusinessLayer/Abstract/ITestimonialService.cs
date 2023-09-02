using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface ITestimonialService
    {
        List<Testimonial> GetTestimonials();
        Testimonial GetTestimonial(int id);
        void Add(Testimonial testimonial);
        void Update(Testimonial testimonial);
        void Activity(int id);
    }
}
