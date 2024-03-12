using Core.Domain.Common;
using FluentValidation;

namespace Core.UseCase.V1.BookingOperation.Commands.Update
{
    public class UpdateBookingValidation : AbstractValidator<UpdateBookingCommand>
    {

        public UpdateBookingValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage(string.Format(ErrorMessage.MUST_BE_A_POSITIVE_NUMBER, "{PropertyName}"));

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
