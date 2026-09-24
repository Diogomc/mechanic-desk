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
            CarId = updateWorkOrderDTO.CarId,
            ClientId = updateWorkOrderDTO.ClientId
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
            CarId = workOrder.CarId,
            ClientId = workOrder.ClientId
        };
    }
}
