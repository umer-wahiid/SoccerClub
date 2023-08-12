using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class Product
    {
        public int Productid { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Short Description")]
        public string Description { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public int Price { get; set; }
        [Required]
        [StringLength(30)]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
