
namespace Core.Domain.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string Client { get; set; } = null!;
        public DateTime BookingDate { get; set; }
        public int TourId { get; set; }
    }
}
