using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        About GetAboutId(int id);
        void Update(About about);
        About GetAbout();
    }
}
