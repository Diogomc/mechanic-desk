using MechanicDesk.DTOs.WorkOrderDTO;
using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Mappers.WorkOrderMappers;

public static class UpdateWorkOrderMappingExtensions
{
    public static WorkOrder ToWorkOrder(this UpdateWorkOrderDTO updateWorkOrderDTO)
    {
        return new WorkOrder
        {
            ProblemDescription = updateWorkOrderDTO.ProblemDescription,
            InitialDate = updateWorkOrderDTO.InitialDate,
            FinalDate = updateWorkOrderDTO.FinalDate,
            WorkerName = updateWorkOrderDTO.WorkerName,
            IsFinished = updateWorkOrderDTO.IsFinished,
            WorkOrderParts = updateWorkOrderDTO.WorkOrderParts,
            WorkOrderServices = updateWorkOrderDTO.WorkOrderServices,
        };
    }
    public static UpdateWorkOrderDTO ToUpdateWorkOrderDTO(this WorkOrder workOrder)
    {
        return new UpdateWorkOrderDTO
        {
            Id = workOrder.Id,
            ProblemDescription = workOrder.ProblemDescription,
            InitialDate = workOrder.InitialDate,
            FinalDate = workOrder.FinalDate,
            WorkerName = workOrder.WorkerName,
            IsFinished = workOrder.IsFinished,
            WorkOrderParts = workOrder.WorkOrderParts,
            WorkOrderServices = workOrder.WorkOrderServices,
        };
    }
}
