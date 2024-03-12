namespace PruebaApi.Models
{
    public record struct UpdateTourVM(
       string Name,
       string Destiny,
       DateTime StartDate,
       DateTime EndDate,
       decimal Price)
    {
    }
}
