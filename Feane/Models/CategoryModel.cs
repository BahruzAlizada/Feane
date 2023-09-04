using System.ComponentModel.DataAnnotations;

namespace Feane.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Category Name can not be null")]
        public string CategoryName { get; set; }
    }
}
