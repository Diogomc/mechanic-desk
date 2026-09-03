using FluentValidation;
using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Validators.WorkOrderAggValidators;

public class WorkOrderServiceValidator : AbstractValidator<WorkOrderService>
{
    public WorkOrderServiceValidator()
    {
        RuleFor(w => w.ServiceName)
            .MaximumLength(100).WithMessage("Service name cannot exceed 100 characters.");

        RuleFor(w => w.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.");
    }
}
