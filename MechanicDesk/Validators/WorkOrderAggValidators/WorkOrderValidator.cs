using FluentValidation;
using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Validators.WorkOrderAggValidators;

public class WorkOrderValidator : AbstractValidator<WorkOrder>
{
    public WorkOrderValidator()
    {
        RuleFor(w => w.ProblemDescription)
            .NotEmpty().WithMessage("Problem description cannot be empty.")
            .MaximumLength(500).WithMessage("Problem description cannot exceed 500 characters.");

        RuleFor(w => w.InitialDate)
            .NotEmpty().WithMessage("Initial date cannot be empty.");
            
        RuleFor(w => w.FinalDate)
            .GreaterThanOrEqualTo(w => w.InitialDate).WithMessage("The final date is cannot be earlier than the initial date.");

        RuleFor(w => w.WorkerName)
            .NotEmpty().WithMessage("Worker name cannot be empty.")
            .MaximumLength(20).WithMessage("Worker name cannot exceed 20 characters.");

        RuleFor(w => w.IsFinished)
            .NotNull().WithMessage("IsFinished cannot be null.");


        RuleForEach(w => w.WorkOrderServices)
            .SetValidator(new WorkOrderServiceValidator());

        RuleForEach(w => w.WorkOrderParts)
            .SetValidator(new WorkOrderPartsValidator());



    }
}
