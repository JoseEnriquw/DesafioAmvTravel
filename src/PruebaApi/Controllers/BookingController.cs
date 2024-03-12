using Core.Domain.Classes;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using Core.UseCase.V1.BookingOperation.Commands.Create;
using Core.UseCase.V1.BookingOperation.Commands.Update;
using Core.UseCase.V1.BookingOperation.Queries.List;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Helpers;
using PruebaApi.Models;

namespace PruebaApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookingController : ApiControllerBase
    {
        /// <summary>
        /// Creación de nuevo Booking
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(BookingDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateBookingCommand body) => Result(await Sender.Send(body));


        /// <summary>
        /// Actualización de Booking
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BookingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateBookingVM body) => Result(await Sender.Send(new UpdateBookingCommand
        {
            Id = id,
            TourId = body.TourId,
            BookingDate = body.BookingDate,
            Client = body.Client
        }));


        /// Listado de Bookings de la base de datos
        /// <remarks>en los remarks podemos documentar información más detallada</remarks>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Booking>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get() => Result(await Sender.Send(new ListBookings()));

    }
}
