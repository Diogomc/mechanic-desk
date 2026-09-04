using MechanicDesk.DataBase;
using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;
using MechanicDesk.UnitOfWork;

namespace MechanicDesk.Services;

public class ClientServices : IClientServices
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Client> GetAll()
    {
        return _unitOfWork.Clients.GetAll();
    }
}
