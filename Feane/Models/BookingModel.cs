using System.ComponentModel.DataAnnotations;

namespace Feane.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="FullName can not be null")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Email can not be null")]
        [EmailAddress(ErrorMessage ="This is not Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Phone number can not be null")]
        [Phone(ErrorMessage ="This is not Phone Number")]
        public string PhoneNumber { get; set; }
        public bool IsTwoPerson { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow.AddHours(4);
        [Required(ErrorMessage ="Day can not be null")]
        public DateTime Day { get; set; }
        [Required(ErrorMessage = "Time can not be null")]
        public DateTime Time { get; set; }
    }
}
