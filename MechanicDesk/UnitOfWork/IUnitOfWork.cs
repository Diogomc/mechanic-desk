using MechanicDesk.Repository.CarRepository;
using MechanicDesk.Repository.ClientRepository;
using MechanicDesk.Repository.WorkOrderRepository;

namespace MechanicDesk.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    ICarRepository Cars { get; }
    IWorkOrderRepository WorkOrders { get; }
    void Commit();
}
