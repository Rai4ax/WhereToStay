using WhereToStay.Models;

namespace WhereToStay.ViewModel
{
    public class SearchHotel
    {
        public IEnumerable<HotelImage>? Hotel { get; set; }    
        public List<Room>? Rooms { get; set; }
    }
}
