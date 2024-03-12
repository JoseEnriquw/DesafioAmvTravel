using Core.Common.Interfaces;
using Core.Domain.Classes;
using Core.Domain.Common;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Core.UseCase.V1.TourOperation.Commands.Update
{
    public class UpdateTourCommand : IRequest<Response<TourDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Destiny { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, Response<TourDto>>
    {
        private readonly IRepositoryEF _repository;

        public UpdateTourCommandHandler(IRepositoryEF repository)
        {
            _repository = repository;
        }

        public async Task<Response<TourDto>> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _repository.FindAsync<Tour>(x => x.Id == request.Id);

            var response = new Response<TourDto>();
            if (tour is null)
            {
                response.AddNotification("#123", nameof(request.Id), string.Format(ErrorMessage.NOT_FOUND_GET_BY_ID, request.Id, nameof(Tour)));
                response.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                tour.Name = request.Name;
                tour.StartDate = request.StartDate;
                tour.EndDate = request.EndDate;
                tour.Destiny = request.Destiny;
                tour.Price = request.Price;

                _repository.Update(tour);
                await _repository.SaveChangesAsync();

                response.Content = new()
                {
                    Id = tour.Id,
                    Name = tour.Name,
                    StartDate = tour.StartDate,
                    EndDate = tour.EndDate,
                    Destiny = tour.Destiny,
                    Price = tour.Price
                };

                response.StatusCode = HttpStatusCode.OK;
            }

            return response;
        }
    }
}
