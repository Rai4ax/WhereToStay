using System.ComponentModel.DataAnnotations;
namespace WhereToStay.Models
{
    public class contactMessages
    {
        [Key]
        public int messageID { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        
    }
}
