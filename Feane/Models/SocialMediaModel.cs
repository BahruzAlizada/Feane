using System.ComponentModel.DataAnnotations;

namespace Feane.Models
{
    public class SocialMediaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This column can not be null")]
        public string FacebookLink { get; set; }
        [Required(ErrorMessage = "This column can not be null")]
        public string TvitterLink { get; set; }
        [Required(ErrorMessage = "This column can not be null")]
        public string InstagramLink { get; set; }
        [Required(ErrorMessage = "This column can not be null")]
        public string LinkedinLink { get; set; }
    }
}
