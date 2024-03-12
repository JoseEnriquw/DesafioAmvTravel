using Core.Common.Interfaces;
using Core.Domain.Classes;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using MediatR;

namespace Core.UseCase.V1.BookingOperation.Commands.Create
{
    public class CreateBookingCommand : IRequest<Response<BookingDto>>
    {
        public string Client { get; set; } = null!;
        public DateTime BookingDate { get; set; }
        public int TourId { get; set; }
    }

    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Response<BookingDto>>
    {
        private readonly IRepositoryEF _repository;

        public CreateBookingCommandHandler(IRepositoryEF repository)
        {
            _repository = repository;
        }

        public async Task<Response<BookingDto>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = new Booking
            {
                BookingDate = request.BookingDate,
                Client = request.Client,
                TourId = request.TourId                
            };

            _repository.Insert(entity);
            await _repository.SaveChangesAsync();

            return new()
            {
                Content = new()
                {
                    Id = entity.Id,
                    Client = entity.Client,
                    TourId= entity.TourId,
                    BookingDate= entity.BookingDate                    
                },
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
