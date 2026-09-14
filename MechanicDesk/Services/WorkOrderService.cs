using MechanicDesk.DTOs.WorkOrderDTO;
using MechanicDesk.Mappers.WorkOrderMappers;
using MechanicDesk.Models.WorkOrderAgg;
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

        if (workOrder is null) throw new Exception("Work order not found");

        return workOrder.ToWorkOrderDTO();

    }
    public GetWorkOrderDTO CreateWorkOrder(CreateWorkOrderDTO createWorkOrderDTO)
    {
        var workOrder = createWorkOrderDTO.ToWorkOrder();

        var car = _unitOfWork.Cars.GetById(c => c.LicencePlate == createWorkOrderDTO.LicencePlate);
        if (car is null) throw new KeyNotFoundException($"Car with license plate {createWorkOrderDTO.LicencePlate} is not found");

        var client = _unitOfWork.Clients.GetById(cl => cl.Id == createWorkOrderDTO.ClientId);
        if (client is null) throw new KeyNotFoundException($"Client with id {createWorkOrderDTO.ClientId} is not found");

        workOrder.CarId = car.Id;
        workOrder.ClientId = client.Id;

        _unitOfWork.WorkOrders.Create(workOrder);
        _unitOfWork.Commit();

        return workOrder.ToWorkOrderDTO();

    }
    public UpdateWorkOrderDTO UpdateWorkOrder(int id, UpdateWorkOrderDTO updateWorkOrderDTO)
    {
        var workOrder = updateWorkOrderDTO.ToWorkOrder();
        if (id != updateWorkOrderDTO.Id) throw new ArgumentException("IDs do not match ");

        var updated = _unitOfWork.WorkOrders.Update(workOrder);
        if (updated is null) throw new KeyNotFoundException($"Work Order by Id: {id} not found");

        _unitOfWork.Commit();

        return updated.ToUpdateWorkOrderDTO();
    }

    public WorkOrder Delete(int id)
    {
        var workOrder = _unitOfWork.WorkOrders.GetById(wo => wo.Id == id);

        if (workOrder is null) throw new KeyNotFoundException($"Work order by id: {id} is not found");

        var delete = _unitOfWork.WorkOrders.Delete(workOrder);
        _unitOfWork.Commit();

        return workOrder;

    }
}
