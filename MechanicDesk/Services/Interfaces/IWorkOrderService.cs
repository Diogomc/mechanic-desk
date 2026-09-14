using MechanicDesk.DTOs.WorkOrderDTO;
using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Services.Interfaces;

public interface IWorkOrderService
{
    IEnumerable<GetWorkOrderDTO> GetAllWorkOrders();
    GetWorkOrderDTO GetById (int id);
    GetWorkOrderDTO CreateWorkOrder(CreateWorkOrderDTO createWorkOrderDTO);
    UpdateWorkOrderDTO UpdateWorkOrder(int id, UpdateWorkOrderDTO updateWorkOrderDTO);
    WorkOrder Delete(int id);
}
