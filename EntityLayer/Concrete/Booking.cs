using CoreLayer.Entity;
using System;


namespace EntityLayer.Concrete
{
    public class Booking : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsTwoPerson { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime Day { get; set; }
        public DateTime Time { get; set; }
    }
}
