using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotel.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int BookingID { get; set; }

        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cost { get; set; }

        public Booking Booking { get; set; }
    }
}
