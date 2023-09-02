using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFTestimonialDal : EfRepositoryBase<Testimonial, Context>, ITestimonialDal
    {
        public void Activity(int id)
        {
            using(var context = new Context())
            {
                var testimonial = context.Testimonials.FirstOrDefault(x=> x.Id == id);
                if (testimonial.IsDeactive)
                    testimonial.IsDeactive = false;
                else
                    testimonial.IsDeactive = true;

                context.SaveChanges();
            }
        }
    }
}
