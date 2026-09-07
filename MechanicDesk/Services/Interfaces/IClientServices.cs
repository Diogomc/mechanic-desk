using MechanicDesk.DTOs.ClientDTO;
using MechanicDesk.Models;
using MechanicDesk.Repository.ClientRepository;
using System.Linq.Expressions;

namespace MechanicDesk.Services.Interfaces;

public interface IClientServices
{
    IEnumerable<Client> GetAll();
    Client GetById(int id);
    Client Create(CreateClientDTO createClientDTO);
    Client Update(int id, UpdateClientDTO updateClientDTO);
    Client Delete(int id);
}
