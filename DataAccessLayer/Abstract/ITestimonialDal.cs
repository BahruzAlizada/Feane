using Core.DataAccess;
using EntityLayer.Concrete;
using System;

namespace DataAccessLayer.Abstract
{
    public interface ITestimonialDal : IRepositoryBase<Testimonial>
    {
        void Activity(int id);
    }
}
