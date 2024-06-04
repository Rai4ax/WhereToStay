namespace WhereToStay.Models
{
    public class HotelImage

    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int ImageId { get; set; }
        public Image? Image { get; set; }
    }

}
