using System.ComponentModel.DataAnnotations;

namespace WhereToStay.Models
{
    public class Hotel
    {
        [Key]
        public int hotel_id { get; set; }
        [StringLength(100)]
        public string name { get; set; }
        [StringLength(100)]
        public string city { get; set; }
        [StringLength(100)]
        public string address { get; set; } 
        [StringLength(16)]
        public string phone_number { get; set; }// max phone lenght according to standarts 15digits
        public double? rating { get; set; }
        public string description { get; set; }
        public Features? Features { get; set; }
        public ICollection<Destination>? HotelDestinationID { get; set; }

        public ICollection<HotelRoom>? HotelRooms { get; set; }
        public ICollection<HotelImage>? HotelImages { get; set; }
        public int? FeaturesID { get; set; }
        


    }
}
