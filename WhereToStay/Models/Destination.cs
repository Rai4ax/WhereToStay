using System.ComponentModel.DataAnnotations;

namespace WhereToStay.Models
{
    public class Destination
    {
        [Key]
        public int destinaiton_id { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        public Image? image { get; set; }
    }
}
