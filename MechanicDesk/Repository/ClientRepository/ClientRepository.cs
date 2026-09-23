using MechanicDesk.DataBase;
using MechanicDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace MechanicDesk.Repository.ClientRepository;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
    }
    public IEnumerable<Client> GetAllClientsFullInfos()
    {
        return _context.Clients
            .Include(c => c.Cars)
            .AsNoTracking()
            .ToList();
    }
    public Client? GetClientFullInformationById(int id)
    {
        return _context.Clients
            .Include(c => c.Cars)
            .AsNoTracking()
            .FirstOrDefault(c => c.Id == id);
    }
}
