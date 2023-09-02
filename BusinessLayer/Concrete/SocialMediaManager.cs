using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal socialMediaDal;
        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            this.socialMediaDal=socialMediaDal;
        }

        public void Add(SocialMedia socialMedia)
        {
            socialMediaDal.Add(socialMedia);
        }

        public SocialMedia GetSocialMedia()
        {
            return socialMediaDal.Get();
        }

        public SocialMedia GetSocialMediaId(int id)
        {
            return socialMediaDal.Get(x => x.Id == id);
        }

        public void Update(SocialMedia socialMedia)
        {
            socialMediaDal.Update(socialMedia);
        }
    }
}
