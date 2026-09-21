namespace TennisBooking.Common
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CreateFrom { get; set; }
        public Guid UpdateFrom { get; set; }
    }
}
