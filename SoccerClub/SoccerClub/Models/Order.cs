using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        [Required(ErrorMessage = "Enter Your Shipping Address")]
        [MaxLength(200, ErrorMessage = "Only 200 Characters are Allowed"), Display(Name = "Shipping Address")]

        public string Address { get; set; }
    }
}
