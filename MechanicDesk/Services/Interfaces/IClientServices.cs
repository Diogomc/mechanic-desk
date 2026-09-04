using MechanicDesk.Models;

namespace MechanicDesk.Services.Interfaces;

public interface IClientServices
{
    IEnumerable<Client> GetAll();
}
