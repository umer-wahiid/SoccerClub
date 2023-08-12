using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category Name"), Required]
        public string CategoryName { get; set; }
    }
}
