using TennisBooking.Common;

namespace TennisBooking.Entities
{
    public class TennisCourt : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
