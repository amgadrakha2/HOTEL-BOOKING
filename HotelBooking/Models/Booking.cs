using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotel.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        public int CustomerID { get; set; }

        public int RoomID { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime?CheckOutDate { get; set; }

        public int NumAdults { get; set; }

        public int NumChildren { get; set; }

        public int? NumberOfRooms { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalCost { get; set; }

        public Customer Customers { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Room> Rooms { get;}


    }
}
