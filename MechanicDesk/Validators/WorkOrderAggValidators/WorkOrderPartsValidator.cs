using FluentValidation;
using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Validators.WorkOrderAggValidators;

public class WorkOrderPartsValidator : AbstractValidator<WorkOrderParts>
{
    public WorkOrderPartsValidator()
    {
        RuleFor(w => w.PartName)
            .MaximumLength(300).WithMessage("Part name cannot exceed 300 characters.");

        RuleFor(w => w.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.");
    }
}
