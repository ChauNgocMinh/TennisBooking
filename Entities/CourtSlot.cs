using TennisBooking.Common;

namespace TennisBooking.Entities
{
    public class CourtSlot : BaseModel
    {
        public Guid CourtId { get; set; }

        public Guid? BookingId { get; set; }

        public DateTime SlotStart { get; set; }

        public Booking? Booking { get; set; }
    }
}
