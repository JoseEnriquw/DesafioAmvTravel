using Core.Domain.Common;
using FluentValidation;

namespace Core.UseCase.V1.BookingOperation.Commands.Create
{
    public class CreateBookingCommandValidation : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidation()
        {
            RuleFor(x => x.Client)
             .NotNull()
             .WithMessage(string.Format(ErrorMessage.NULL_VALUE, "{PropertyName}"))
             .NotEmpty()
             .WithMessage(string.Format(ErrorMessage.EMPTY_VALUE, "{PropertyName}"))
             .MaximumLength(200)
             .WithMessage(string.Format(ErrorMessage.MAXIMUM_LENGTH, "{PropertyName}", "{MaxLength}"));

            RuleFor(x => x.BookingDate)
             .NotNull()
             .WithMessage(string.Format(ErrorMessage.NULL_VALUE, "{PropertyName}"));

            RuleFor(x => x.TourId)
             .GreaterThan(0)
             .WithMessage(string.Format(ErrorMessage.MUST_BE_A_POSITIVE_NUMBER, "{PropertyName}"));
        }
    }
}
