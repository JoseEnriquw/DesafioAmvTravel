namespace PruebaApi.Models
{
    public record struct UpdateBookingVM(
        string Client,
        DateTime BookingDate,
        int TourId
        ) { }
}
