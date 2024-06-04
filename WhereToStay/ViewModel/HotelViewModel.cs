using WhereToStay.Models;

namespace WhereToStay.ViewModel
{
    public class HotelViewModel
    {
        public Hotel Hotel { get; set; }
        public List<Image>? Images { get; set; }

        public Features features { get; set; }
        public List<Room> rooms { get; set; }
        public Reservation reservations { get; set; }

        public List<int> roomSizesCheck { get; set; }
        public int? HotelID { get; set; }
        public DateTime? checkin { get; set; }
        public DateTime? checkout { get; set; }
        public string? roomName { get; set; }
        public HotelViewModel hvm { get; set; }
    }
}
