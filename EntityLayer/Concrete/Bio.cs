using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Bio : IEntity
    {
        public int Id { get; set; }
        public string HeaderLogoName { get; set; }
        public string FooterLocation { get; set; }
        public string FooterPhone { get; set; }
        public string FooterEmail { get; set; }
        public string FooterDescription { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
    }
}
