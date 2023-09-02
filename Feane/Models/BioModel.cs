using System.ComponentModel.DataAnnotations;

namespace Feane.Models
{
    public class BioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Logo can not be null")]
        public string HeaderLogoName { get; set; }
        [Required(ErrorMessage = "Location can not be null")]
        public string FooterLocation { get; set; }
        [Required(ErrorMessage = "Phone can not be null")]
        public string FooterPhone { get; set; }
        [Required(ErrorMessage = "Email can not be null")]
        [EmailAddress(ErrorMessage ="This is not email")]
        public string FooterEmail { get; set; }
        [Required(ErrorMessage = "Description can not be null")]
        public string FooterDescription { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
    }
}
