
namespace Core.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string Client { get; set; } = null!;
        public DateTime BookingDate { get; set; }
        public int TourId { get; set; }

        public virtual Tour Tour { get; set; }= null!;
    }
}
