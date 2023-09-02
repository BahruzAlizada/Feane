using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Concrete
{
    public class BioManager : IBioService
    {
        private readonly IBioDal bioDal;
        public BioManager(IBioDal bioDal)
        {
            this.bioDal = bioDal;
        }

        public void Add(Bio bio)
        {
            bioDal.Add(bio);
        }

        public Bio GetBio()
        {
            return bioDal.Get();
        }

        public Bio GetBioId(int id)
        {
            return bioDal.Get(x => x.Id == id);
        }

        public void Update(Bio bio)
        {
            bioDal.Update(bio);
        }
    }
}
