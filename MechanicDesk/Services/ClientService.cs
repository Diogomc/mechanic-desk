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

public class ClientService : IClientServices
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<GetClientDTO> GetAll()
    {
        
        return _unitOfWork.Clients.GetAll().ToGetClientDTOList();
    }
    public GetClientDTO GetById(int id)
    {
        var getId = _unitOfWork.Clients.GetById(c => c.Id == id);

        if (getId is null) 
        { 
            throw new KeyNotFoundException($"Client by id: {id} is not found");
        }

        return getId.ToGetClientDTO(); 
    }
    public GetClientDTO Create(CreateClientDTO createClientDTO)
    {
        var created = createClientDTO.ToClient();

        _unitOfWork.Clients.Create(created);
        _unitOfWork.Commit();

        return created.ToGetClientDTO();
        
    }
    public UpdateClientDTO Update(int id, UpdateClientDTO updateClientDTO)
    {
        var client = updateClientDTO.ToClient();
        if (client.Id != id) throw new ArgumentException("IDs do not match");

        var update = _unitOfWork.Clients.Update(client);
        if (update is null) throw new KeyNotFoundException($"Client by id: {id} is not found");

        _unitOfWork.Commit();
        return update.ToUpdateClientDTO();

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
