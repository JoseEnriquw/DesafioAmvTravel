using Core.Common.Interfaces;
using Core.Domain.Classes;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using MediatR;

namespace Core.UseCase.V1.TourOperation.Commands.Create
{
    public class CreateTourCommand : IRequest<Response<TourDto>>
    {
        public string Name { get; set; } = null!;
        public string Destiny { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, Response<TourDto>>
    {
        private readonly IRepositoryEF _repository;

        public CreateTourCommandHandler(IRepositoryEF repository)
        {
            _repository = repository;
        }

        public async Task<Response<TourDto>> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            var entity = new Tour
            {
                Name = request.Name,
                Destiny = request.Destiny,
                Price = request.Price,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            _repository.Insert(entity);
            await _repository.SaveChangesAsync();

            return new()
            {
                Content = new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Destiny = entity.Destiny,
                    Price = entity.Price,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate
                },
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
