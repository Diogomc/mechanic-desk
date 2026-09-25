using MechanicDesk.DataBase;
using MechanicDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace MechanicDesk.Repository.CarRepository;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context)
    {
    }

    public override IEnumerable<Car> GetAll()
    {
        return _context.Cars
            .Include(w => w.WorkOrders);
    }
    public Car? GetCarFullInformationById(int id)
    {
        return _context.Cars
            .Include(w => w.WorkOrders)
            .AsNoTracking()
            .FirstOrDefault(c => c.Id == id);
    }
    
}
