using FluentValidation;
using MechanicDesk.DTOs.RegisterDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Validators;

public class RegisterValidator : AbstractValidator<RegisterDTO>
{
    public RegisterValidator()
    {
        RuleFor(u => u.UserName)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(3).MaximumLength(20).WithMessage("The username must be between 3 and 20 characters long.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("The password is required")
            .MinimumLength(8).WithMessage("Your password length must be at least 8")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16");

        RuleFor(u => u.Role)
            .NotEmpty().WithMessage("The role is required");

    }
}
