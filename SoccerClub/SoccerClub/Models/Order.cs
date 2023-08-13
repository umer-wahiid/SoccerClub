using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
