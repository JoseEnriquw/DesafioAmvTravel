using Core.Common.Interfaces;
using Core.Domain.Classes;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using MediatR;

namespace Core.UseCase.V1.TourOperation.Queries.List
{
    public class ListTours : IRequest<Response<List<TourDto>>>
    {
    }

    public class ListToursHandler : IRequestHandler<ListTours, Response<List<TourDto>>>
    {
        private readonly IRepositoryEF _repository;

        public ListToursHandler(IRepositoryEF repository)
        {
            _repository = repository;
        }

        public async Task<Response<List<TourDto>>> Handle(ListTours request, CancellationToken cancellationToken)
        {
            var tours = await _repository.GetAllAsync<Tour>();

            return new Response<List<TourDto>>()
            {
                Content = tours.Select(x => new TourDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Destiny = x.Destiny,
                    EndDate = x.EndDate,
                    Price = x.Price,
                    StartDate = x.StartDate,
                }).ToList(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
    }
}
