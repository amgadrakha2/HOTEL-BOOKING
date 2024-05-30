using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string NationalID { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
