using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feane.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }    
        public string Image { get; set; }
        [Required(ErrorMessage ="Name can not be null")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Description can not be null")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Price can not be null")]
        public double Price { get; set; }
    }
}
