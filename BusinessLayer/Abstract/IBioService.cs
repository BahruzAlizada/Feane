using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IBioService
    {
        Bio GetBio();
        Bio GetBioId(int id);
        void Add(Bio bio);
        void Update(Bio bio);
    }
}
