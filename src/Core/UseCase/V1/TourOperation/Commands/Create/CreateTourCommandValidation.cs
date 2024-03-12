using Core.Domain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.V1.TourOperation.Commands.Create
{
    public class CreateTourCommandValidation : AbstractValidator<CreateTourCommand>
    {
        public CreateTourCommandValidation()
        {
            RuleFor(x => x.Name)
             .NotNull()
             .WithMessage(string.Format(ErrorMessage.NULL_VALUE, "{PropertyName}"))
             .NotEmpty()
             .WithMessage(string.Format(ErrorMessage.EMPTY_VALUE, "{PropertyName}"))
             .MaximumLength(200)
             .WithMessage(string.Format(ErrorMessage.MAXIMUM_LENGTH, "{PropertyName}", "{MaxLength}"));

            RuleFor(x => x.Destiny)
             .NotNull()
             .WithMessage(string.Format(ErrorMessage.NULL_VALUE, "{PropertyName}"))
             .NotEmpty()
             .WithMessage(string.Format(ErrorMessage.EMPTY_VALUE, "{PropertyName}"))
             .MaximumLength(200)
             .WithMessage(string.Format(ErrorMessage.MAXIMUM_LENGTH, "{PropertyName}", "{MaxLength}"));

            RuleFor(x => x.StartDate)
             .NotNull()
             .WithMessage(string.Format(ErrorMessage.NULL_VALUE, "{PropertyName}"));

            RuleFor(x => x.EndDate)
             .NotNull()
             .WithMessage(string.Format(ErrorMessage.NULL_VALUE, "{PropertyName}"));

            RuleFor(x => x.Price)
             .GreaterThan(0)
             .WithMessage(string.Format(ErrorMessage.MUST_BE_A_POSITIVE_NUMBER, "{PropertyName}"));
        }
    }
}
