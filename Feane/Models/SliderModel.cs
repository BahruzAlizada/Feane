
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feane.Models
{
	public class SliderModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Title can not be null")]
		public string Title { get; set; }
        [NotMapped]  
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Description can not be null")]
        public string Description { get; set; }
	}
}
