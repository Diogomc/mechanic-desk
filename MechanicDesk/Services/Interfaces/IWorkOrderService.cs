using MechanicDesk.DTOs.WorkOrderDTO;

namespace MechanicDesk.Services.Interfaces;

public interface IWorkOrderService
{
    IEnumerable<GetWorkOrderDTO> GetAllWorkOrders();
    GetWorkOrderDTO GetById (int id);
    CreateWorkOrderDTO CreateWorkOrder(CreateWorkOrderDTO createWorkOrderDTO);
    UpdateWorkOrderDTO UpdateWorkOrder(int id, UpdateWorkOrderDTO updateWorkOrderDTO);

}
