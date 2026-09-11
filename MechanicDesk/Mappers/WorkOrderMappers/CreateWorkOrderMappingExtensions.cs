using MechanicDesk.DTOs.WorkOrderDTO;
using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Mappers.WorkOrderMappers;

public static class CreateWorkOrderMappingExtensions
{
    public static WorkOrder ToWorkOrder(this CreateWorkOrderDTO createWorkOrderDTO)
    {
        return new WorkOrder
        {
            ProblemDescription = createWorkOrderDTO.ProblemDescription,
            InitialDate = createWorkOrderDTO.InitialDate,
            FinalDate = createWorkOrderDTO.FinalDate,
            WorkerName = createWorkOrderDTO.WorkerName,
            IsFinished = createWorkOrderDTO.IsFinished,
        };
    }

}
