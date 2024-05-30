using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class HotelBranch
    {
        public int BranchID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        [StringLength(15)]
        public string? Phone { get; set; }

        public List<Room>? Rooms { get; set; }
    }
}
