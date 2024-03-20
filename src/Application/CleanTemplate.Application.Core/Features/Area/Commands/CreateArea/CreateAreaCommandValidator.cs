using FluentValidation;
namespace CleanTemplate.Application.Core;

public class CreateAreaCommandValidator : AbstractValidator<CreateAreaCommand>
{
    public CreateAreaCommandValidator()
    {
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
