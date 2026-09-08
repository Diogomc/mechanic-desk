using MechanicDesk.DTOs.ClientDTO;
using MechanicDesk.Models;
using MechanicDesk.Repository.ClientRepository;
using System.Linq.Expressions;

namespace MechanicDesk.Services.Interfaces;

public interface IClientServices
{
    IEnumerable<GetClientDTO> GetAll();
    GetClientDTO GetById(int id);
    GetClientDTO Create(CreateClientDTO createClientDTO);
    UpdateClientDTO Update(int id, UpdateClientDTO updateClientDTO);
    Client Delete(int id);
}
