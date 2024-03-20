using System.Text.RegularExpressions;
using FluentValidation;

namespace CleanTemplate.Application.Core;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotNull().WithMessage("El nombre no debe ser null")
            .NotEmpty().WithMessage("El nombre no debe ser vacio")
            .MaximumLength(20).WithMessage("El nombre no debe tener mas de 20 carácteres");

        RuleFor(p => p.Email)
            .NotNull().WithMessage("La descripción no debe ser null")
            .NotEmpty().WithMessage("La descripción no debe ser vacia")
            .MaximumLength(50).WithMessage("La descripción no debe tener mas de 20 carácteres")
            .EmailAddress().WithMessage("El email no es correcto");

        RuleFor(p => p.PhoneNumber)
            .NotNull().WithMessage("La descripción no debe ser null")
            .NotEmpty().WithMessage("La descripción no debe ser vacia")
            .MinimumLength(10).WithMessage("Número de teléfono no debe tener menos de 10 caracteres.")
            .MaximumLength(20).WithMessage("Número de teléfono no debe superar los 50 caracteres.");

    }
}
