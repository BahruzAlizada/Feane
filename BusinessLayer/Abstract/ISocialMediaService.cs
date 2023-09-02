using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface ISocialMediaService
    {
        SocialMedia GetSocialMedia();
        SocialMedia GetSocialMediaId(int id);
        void Add(SocialMedia socialMedia);
        void Update(SocialMedia socialMedia);
    }
}
