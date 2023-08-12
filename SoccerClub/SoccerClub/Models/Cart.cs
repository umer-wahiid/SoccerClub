using System.ComponentModel.DataAnnotations;


namespace SoccerClub.Models
{
    public class Cart
    {
        public int CartsId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool Status { get; set; } = true;
        [Required]
        public int ProductId { get; set; }
        public Product product { get; set; }

    }
}