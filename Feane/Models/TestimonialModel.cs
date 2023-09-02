using System.ComponentModel.DataAnnotations;

namespace Feane.Models
{
    public class TestimonialModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="FullName can not be null")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Description can not be null")]
        public string Description { get; set; }
    }
}
