using FluentValidation;
using MechanicDesk.DTOs.ClientDTOs;

namespace MechanicDesk.Validators.ValidatorsDTO;

public class CreateClientDTOValidator : AbstractValidator<CreateClientDTO>
{
    public CreateClientDTOValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\d{10,11}$").WithMessage("The phone number must have 10 or 11 digits.");

        RuleFor(c => c.BirthDate)
            .NotEmpty().WithMessage("Birth date is required.")
            .LessThan(DateTime.Today.AddYears(-18)).WithMessage("The client can't be less than 18 years old");
    }
}
