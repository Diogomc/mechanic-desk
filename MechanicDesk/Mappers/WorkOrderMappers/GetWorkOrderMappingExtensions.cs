using MechanicDesk.DTOs.WorkOrderDTO;
using MechanicDesk.Models.WorkOrderAgg;
using Microsoft.Data.SqlClient;

namespace MechanicDesk.Mappers.WorkOrderMappers;

public static class GetWorkOrderMappingExtensions
{
    public static WorkOrder ToWorkOrder(this WorkOrderDTO workOrderDTO)
    {
        return new WorkOrder
        {
            ProblemDescription = workOrderDTO.ProblemDescription,
            InitialDate = workOrderDTO.InitialDate,
            FinalDate = workOrderDTO.FinalDate,
            WorkerName = workOrderDTO.WorkerName,
            IsFinished = workOrderDTO.IsFinished,
            WorkOrderParts = workOrderDTO.WorkOrderParts,
            WorkOrderServices = workOrderDTO.WorkOrderServices,
        };
    }
    public static GetWorkOrderDTO ToWorkOrderDTO(this WorkOrder workOrder)
    {
        return new GetWorkOrderDTO
        {
            Id = workOrder.Id,
            ProblemDescription = workOrder.ProblemDescription,
            InitialDate = workOrder.InitialDate,
            FinalDate = workOrder.FinalDate,
            WorkerName = workOrder.WorkerName,
            IsFinished = workOrder.IsFinished,
            ClientId = workOrder.ClientId,
            CarId = workOrder.CarId,
            WorkOrderParts = workOrder.WorkOrderParts,
            WorkOrderServices = workOrder.WorkOrderServices,
        };
    }

    public static IEnumerable<GetWorkOrderDTO> ToWorkOrderList(this IEnumerable<WorkOrder> workOrders)
    {
        return workOrders.Select(workOrders => new GetWorkOrderDTO
        {
            Id = workOrders.Id,
            ProblemDescription = workOrders.ProblemDescription,
            InitialDate = workOrders.InitialDate,
            FinalDate = workOrders.FinalDate,
            WorkerName = workOrders.WorkerName,
            CarId = workOrders.CarId,
            ClientId = workOrders.ClientId,
            IsFinished = workOrders.IsFinished,        
        }).ToList();
    }
}
