using MechanicDesk.DataBase;
using MechanicDesk.DTOs.ClientDTO;
using MechanicDesk.Mappers.ClientMappers;
using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;
using MechanicDesk.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        return _unitOfWork.Clients.GetAll();
    }
    public Client GetById(int id)
    {
        var getId = _unitOfWork.Clients.GetById(c => c.Id == id);

        if (getId is null) 
        { 
            throw new KeyNotFoundException($"Client by id: {id} is not found");
        }

        return getId; 
    }
    public Client Create(CreateClientDTO createClientDTO)
    {
        var created = createClientDTO.ToClient();

        _unitOfWork.Clients.Create(created);
        _unitOfWork.Commit();

        return created;
        
    }
    public Client Update(int id, Client client)
    {
        var update = _unitOfWork.Clients.Update(client);

        if (update is null) throw new KeyNotFoundException($"Client by id: {id} is not found");

        if(client.Id != id) throw new ArgumentException("IDs do not match");
        _unitOfWork.Commit();
        return update;

    }
    public Client Delete(int id)
    {
        var getId = _unitOfWork.Clients.GetById(c => c.Id == id);

        if(getId is null)
        {
            throw new KeyNotFoundException($"Client by id: {id} is not found");
        }

        var deleted = _unitOfWork.Clients.Delete(getId);
        _unitOfWork.Commit();
        return deleted;
    }   

    
}
