using MechanicDesk.Models;
using MechanicDesk.Repository.ClientRepository;
using System.Linq.Expressions;

namespace MechanicDesk.Services.Interfaces;

public interface IClientServices
{
    IEnumerable<Client> GetAll();
    Client GetById(int id);
    Client Create(Client client);
    Client Update(int id, Client client);
    Client Delete(int id);
}
