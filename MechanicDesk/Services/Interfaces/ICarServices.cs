using MechanicDesk.DTOs.CarDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Services.Interfaces;

public interface ICarServices
{
    IEnumerable<GetCarDTO> GetAllCars();
    GetCarDTO GetCarByID(int id);
    GetCarDTO CreateCar(CreateCarDTO createCarDTO);
    UpdateCarDTO UpdateCar(int id, UpdateCarDTO updateCarDTO);
    Car Delete(int id);
}
