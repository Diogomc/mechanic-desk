using MechanicDesk.DataBase;
using MechanicDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace MechanicDesk.Repository.ClientRepository;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
    }
    public override IEnumerable<Client> GetAll()
    {
        return _context.Clients
            .Include(c => c.Cars)
            .ToList();
    }
}
