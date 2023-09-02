using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class SocialMedia : IEntity
    {
        public int Id { get; set; }
        public string FacebookLink { get; set; }
        public string TvitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string LinkedinLink { get; set; }
    }
}
