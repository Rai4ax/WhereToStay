using System.ComponentModel.DataAnnotations;

namespace WhereToStay.Models
{
    public class Features
    {
        [Key]
        public int features_id { get; set; }

        public bool has_parking { get; set; }
        public bool has_spa { get; set; }
        public bool has_wifi { get; set; }
        public bool has_bar { get; set; }
        public bool has_animals { get; set; }
        public bool has_gym { get; set; }
    }
}
