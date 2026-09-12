using MechanicDesk.DTOs.WorkOrderDTO;
using MechanicDesk.Mappers.WorkOrderMappers;
using MechanicDesk.Services.Interfaces;
using MechanicDesk.UnitOfWork;

namespace MechanicDesk.Services;

public class WorkOrderService : IWorkOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public WorkOrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<GetWorkOrderDTO> GetAllWorkOrders()
    {
        return _unitOfWork.WorkOrders.GetAll().ToWorkOrderList();
    }

    public GetWorkOrderDTO GetById(int id)
    {

        var workOrder = _unitOfWork.WorkOrders.GetById(wo => wo.Id == id);

        if (workOrder is null) throw new Exception("Client not found");

        return workOrder.ToWorkOrderDTO();

    }
    public CreateWorkOrderDTO CreateWorkOrder(CreateWorkOrderDTO createWorkOrderDTO)
    {
        var workOrder = createWorkOrderDTO.ToWorkOrder();

        _unitOfWork.WorkOrders.Create(workOrder);
        _unitOfWork.Commit();

        return workOrder.ToCreateWorkOrderDTO();

    }
    public UpdateWorkOrderDTO UpdateWorkOrder(int id, UpdateWorkOrderDTO updateWorkOrderDTO)
    {
        var workOrder = updateWorkOrderDTO.ToWorkOrder();

        var updated = _unitOfWork.WorkOrders.Update(workOrder);
        _unitOfWork.Commit();

        return updated.ToUpdateWorkOrderDTO();
    }
}
