using Core.Domain.Classes;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using Core.UseCase.V1.TourOperation.Commands.Create;
using Core.UseCase.V1.TourOperation.Commands.Update;
using Core.UseCase.V1.TourOperation.Queries.List;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Helpers;
using PruebaApi.Models;

namespace PruebaApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TourController : ApiControllerBase
    {
        /// <summary>
        /// Creación de nuevo Tour
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TourDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateTourCommand body) => Result(await Sender.Send(body));


        /// <summary>
        /// Actualización de Tour
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TourDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateTourVM body) => Result(await Sender.Send(new UpdateTourCommand
        {
            Id = id,
            Name = body.Name,
            StartDate = body.StartDate,
            Price = body.Price,
            EndDate = body.EndDate,
            Destiny = body.Destiny
        }));


        /// Listado de Tours de la base de datos
        /// <remarks>en los remarks podemos documentar información más detallada</remarks>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Tour>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get() => Result(await Sender.Send(new ListTours()));

    }
}
