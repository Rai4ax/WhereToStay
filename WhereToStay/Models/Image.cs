using System.ComponentModel.DataAnnotations;

namespace WhereToStay.Models
{
    public class Image
    {
        [Key]
        public int image_id { get; set; }
        public byte[] img { get; set; }

        public string? description { get; set; }

        public ICollection<HotelImage> HotelImages { get; set; }

    }
}
