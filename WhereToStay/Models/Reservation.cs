using System.ComponentModel.DataAnnotations;

namespace WhereToStay.Models
{
    public class Reservation
    {
        [Key]
        public int reservation_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public double money_spent { get; set; }

        public User? User { get; set; }
        public string? UserId { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }



    }
}
