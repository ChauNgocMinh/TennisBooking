using TennisBooking.Common;
using TennisBooking.Common.Enum;

namespace TennisBooking.Entities
{
    public class Booking : BaseModel
    {
        public Guid CourtId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public BookingStatus Status { get; set; }

        public ICollection<CourtSlot> Slots { get; set; } = new List<CourtSlot>();

        public TennisCourt Court { get; set; } = null!;
    }
}
