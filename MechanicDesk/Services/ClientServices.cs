using MechanicDesk.DataBase;
using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;
using MechanicDesk.UnitOfWork;
using System.Linq.Expressions;

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
        var clientsList = _unitOfWork.Clients.GetAll();

        if(clientsList is null)
        {
            throw new KeyNotFoundException();
        }

        return clientsList;
    }
    public Client GetById(Expression<Func<Client, bool>> predicate)
    {
        var clientId = _unitOfWork.Clients.GetById(predicate);

        if(clientId is null)
        {
            throw new KeyNotFoundException("Client not found");
        }
        return clientId;
    }

    public Client Create(Client entity)
    {
        var created = _unitOfWork.Clients.Create(entity);
        _unitOfWork.Commit();
        return created;
    }

    public Client Update(Client entity)
    {
        var updated = _unitOfWork.Clients.Update(entity);
        _unitOfWork.Commit();
        return updated;
    }

    public Client Delete(Client entity)
    {
        var deleted = _unitOfWork.Clients.Delete(entity);
        _unitOfWork.Commit();
        return deleted;
    }
     
}
