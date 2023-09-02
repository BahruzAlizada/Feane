using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feane.Models
{
    public class AboutModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage ="Title can not be null")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Description can not be null")]
        public string Description { get; set; }
    }
}
