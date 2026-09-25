using MechanicDesk.Models;

namespace MechanicDesk.Repository.CarRepository;

public interface ICarRepository : IRepository<Car>
{
    public Car? GetCarFullInformationById(int id);
}
