using MechanicDesk.DataBase;
using MechanicDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace MechanicDesk.Repository.CarRepository;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }
    public IEnumerable<Car> GetAll()
    {
        return _context.Cars
            .Include(c => c.Client)
            .ToList();
    }
}
