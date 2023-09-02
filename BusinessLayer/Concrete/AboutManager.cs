using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }

        public About GetAbout()
        {
            return aboutDal.Get();
        }

        public About GetAboutId(int id)
        {
            return aboutDal.Get(x => x.Id == id);
        }

        public void Update(About about)
        {
            aboutDal.Update(about);
        }
    }
}
