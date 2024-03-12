using Core.Common.Interfaces;
using Core.Domain.Classes;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using MediatR;

namespace Core.UseCase.V1.BookingOperation.Queries.List
{
    public class ListBookings : IRequest<Response<List<BookingDto>>>
    {
    }

    public class ListBookingsHandler : IRequestHandler<ListBookings, Response<List<BookingDto>>>
    {
        private readonly IRepositoryEF _repository;

        public ListBookingsHandler(IRepositoryEF repository)
        {
            _repository = repository;
        }

        public async Task<Response<List<BookingDto>>> Handle(ListBookings request, CancellationToken cancellationToken)
        {
            var bookings = await _repository.GetAllAsync<Booking>();

            return new Response<List<BookingDto>>()
            {
                Content = bookings.Select(x => new BookingDto
                {
                    Id = x.Id,
                    Client=x.Client,
                    BookingDate = x.BookingDate,
                    TourId = x.TourId
                }).ToList(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
    }
}
