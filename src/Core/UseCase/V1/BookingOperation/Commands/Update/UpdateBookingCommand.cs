using Core.Common.Interfaces;
using Core.Domain.Classes;
using Core.Domain.Common;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Core.UseCase.V1.BookingOperation.Commands.Update
{
    public class UpdateBookingCommand : IRequest<Response<BookingDto>>
    {
        public int Id { get; set; }
        public string Client { get; set; } = null!;
        public DateTime BookingDate { get; set; }
        public int TourId { get; set; }
    }

    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Response<BookingDto>>
    {
        private readonly IRepositoryEF _repository;

        public UpdateBookingCommandHandler(IRepositoryEF repository)
        {
            _repository = repository;
        }

        public async Task<Response<BookingDto>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _repository.FindAsync<Booking>(x => x.Id == request.Id);

            var response = new Response<BookingDto>();
            if (booking is null)
            {
                response.AddNotification("#123", nameof(request.Id), string.Format(ErrorMessage.NOT_FOUND_GET_BY_ID, request.Id, nameof(Booking)));
                response.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                booking.Client = request.Client;
                booking.BookingDate = request.BookingDate;
                booking.TourId = request.TourId;

                _repository.Update(booking);
                await _repository.SaveChangesAsync();

                response.Content = new()
                {
                    Id = booking.Id,
                    TourId = booking.TourId,
                    BookingDate = booking.BookingDate,
                    Client = booking.Client
                };

                response.StatusCode = HttpStatusCode.OK;
            }

            return response;
        }
    }
}
