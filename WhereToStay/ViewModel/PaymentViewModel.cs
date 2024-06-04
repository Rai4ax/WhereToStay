using WhereToStay.Models;

namespace WhereToStay.ViewModel
{
    public class PaymentViewModel
    {
       public int? roomId { get; set; }
        public List<Image>? images { get; set; }
       public DateTime? checkin { get; set; }
       public DateTime? checkout { get; set; }
        public double roomPrice { get; set; }
        public string? roomName { get; set; }
    }
}
