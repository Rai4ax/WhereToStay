namespace WhereToStay.Models
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        
        

    }
}
