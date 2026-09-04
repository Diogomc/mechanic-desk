using MechanicDesk.DataBase;
using MechanicDesk.Models;

namespace MechanicDesk.Repository.ClientRepository;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
        
    }
}
