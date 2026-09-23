using MechanicDesk.Models;

namespace MechanicDesk.Repository.ClientRepository;

public interface IClientRepository : IRepository<Client>
{
    Client? GetClientFullInformationById(int id);
    IEnumerable<Client> GetAllClientsFullInfos();
}
