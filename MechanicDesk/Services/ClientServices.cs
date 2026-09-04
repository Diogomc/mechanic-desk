using MechanicDesk.DataBase;
using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;

namespace MechanicDesk.Services;

public class ClientServices : IClientServices
{
    private readonly AppDbContext _appDbContext;

    public ClientServices(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IEnumerable<Client> GetAll()
    {
        return _appDbContext.Clients.ToList();
    }
}
