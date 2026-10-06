using MechanicDesk.DTOs.WorkOrderDTO;
using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Mappers.WorkOrderMappers;

public static class UpdateWorkOrderMappingExtensions
{
    public static void ToWorkOrder(this UpdateWorkOrderDTO updateWorkOrderDTO, WorkOrder workOrder)
    {
            workOrder.ProblemDescription = updateWorkOrderDTO.ProblemDescription;
            workOrder.InitialDate = updateWorkOrderDTO.InitialDate;
            workOrder.FinalDate = updateWorkOrderDTO.FinalDate;
            workOrder.WorkerName = updateWorkOrderDTO.WorkerName;
            workOrder.IsFinished = updateWorkOrderDTO.IsFinished;
            workOrder.CarId = updateWorkOrderDTO.CarId;
            workOrder.ClientId = updateWorkOrderDTO.ClientId;
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
