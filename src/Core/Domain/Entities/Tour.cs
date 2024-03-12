
namespace Core.Domain.Entities
{
    public class Tour
    {
        public Tour() 
        {
            Bookings = new HashSet<Booking>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Destiny { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        
        public virtual ICollection<Booking> Bookings { get; set; }
        public string MostrarInformacion()
        {
            return $"Name:{Name}, Destiny: {Destiny}, StartDate: {StartDate}, EndDate: {EndDate}, Price: {Price}";
        }
    }
}
