using FluentValidation;
using MechanicDesk.DTOs.CarDTO;

namespace MechanicDesk.Validators.CarDTOValidators;

public class CreateCarDTOValidator : AbstractValidator<CreateCarDTO>
{
    public CreateCarDTOValidator()
    {
        RuleFor(c => c.Model)
            .NotEmpty().WithMessage("Car model is required.")
            .MaximumLength(20).WithMessage("Car model cannot exceed 20 characters.");

        RuleFor(c => c.Year)
            .GreaterThan(1900).WithMessage("The car year must be greater than 1900.");

        RuleFor(c => c.Brand)
            .NotEmpty().WithMessage("Car brand is required.")
            .MaximumLength(20).WithMessage("Car brand cannot exceed 20 characters.");

        RuleFor(c => c.LicencePlate)
            .NotEmpty().WithMessage("Licence plate is required.")
            .Length(7).WithMessage("Licence plate must be exactly 7 characters long.");

        RuleFor(c => c.ClientId)
            .GreaterThan(0).WithMessage("A valid Client Id is required.");
    }
}
