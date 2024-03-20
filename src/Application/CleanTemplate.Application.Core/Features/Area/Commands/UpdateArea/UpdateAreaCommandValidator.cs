using FluentValidation;

namespace CleanTemplate.Application.Core;

public class UpdateAreaCommandValidator : AbstractValidator<UpdateAreaCommand>
{
    public UpdateAreaCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotNull().WithMessage("El ID, no debe ser null")
            .NotEmpty().WithMessage("El ID no debe ser vacio")
            .GreaterThan(0).WithMessage("El ID no es valido");

        RuleFor(p => p.Name)
            .NotNull().WithMessage("El nombre no debe ser null")
            .NotEmpty().WithMessage("El nombre no debe ser vacio")
            .MaximumLength(20).WithMessage("El nombre no debe tener mas de 20 carácteres");

        RuleFor(p => p.Description)
            .NotNull().WithMessage("La descripción no debe ser null")
            .NotEmpty().WithMessage("La descripción no debe ser vacia")
            .MaximumLength(30).WithMessage("La descripción no debe tener mas de 20 carácteres");
    }
}
