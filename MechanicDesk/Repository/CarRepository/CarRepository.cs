using MechanicDesk.DataBase;
using MechanicDesk.Models;

namespace MechanicDesk.Repository.CarRepository;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
        
    }
}
