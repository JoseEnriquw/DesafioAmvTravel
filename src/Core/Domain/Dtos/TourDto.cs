
namespace Core.Domain.Dtos
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Destiny { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
