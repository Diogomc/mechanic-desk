using MechanicDesk.DataBase;
using MechanicDesk.Models;
using MechanicDesk.Models.WorkOrderAgg;
using MechanicDesk.Repository.CarRepository;
using MechanicDesk.Repository.ClientRepository;
using MechanicDesk.Repository.WorkOrderRepository;

namespace MechanicDesk.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{

    public IClientRepository Clients { get; }
    public ICarRepository Cars { get; }
    public IWorkOrderRepository WorkOrders { get; set; }
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context,
        IClientRepository clientRepository,
        ICarRepository carRepository,
        IWorkOrderRepository workOrderRepository)
    {
         _context = context;
        Clients = clientRepository;
        Cars = carRepository;
        WorkOrders = workOrderRepository;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
