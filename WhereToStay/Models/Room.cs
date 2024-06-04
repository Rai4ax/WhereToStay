using System.ComponentModel.DataAnnotations;

namespace WhereToStay.Models
{
    public class Room
    {
        [Key]
        public int room_id { get; set; }
        public int room_size { get; set; }
        public string room_name { get; set; }
        public double price { get; set; }
        public ICollection<HotelRoom>? HotelRooms { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }

    }
}
