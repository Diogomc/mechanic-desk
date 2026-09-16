using MechanicDesk.DTOs.CarDTO;
using MechanicDesk.Mappers.CarMappers;
using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;
using MechanicDesk.UnitOfWork;

namespace MechanicDesk.Services;

public class CarServices : ICarServices
{
    private readonly IUnitOfWork _unitOfWork;
    public CarServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<GetCarDTO> GetAllCars()
    {
        return _unitOfWork.Cars.GetAll().ToCarDTOList();
    }
    public GetCarDTO GetCarByID(int id)
    {
        var carId = _unitOfWork.Cars.GetById(c => c.Id == id);

        if (carId is null) throw new KeyNotFoundException($"Car by Id: {id} is not found");

        return carId.ToCarDTO();
    }
    public GetCarDTO CreateCar(CreateCarDTO createCarDTO)
    {
        var created = createCarDTO.ToCreateCar();

        _unitOfWork.Cars.Create(created);
        _unitOfWork.Commit();

        return created.ToCarDTO();
    }
    public UpdateCarDTO UpdateCar(int id, UpdateCarDTO updateCarDTO)
    {
        var updated = updateCarDTO.ToUpdateCar();
        if (updated.Id != id) throw new ArgumentException("IDs do not match");

        _unitOfWork.Cars.Update(updated);
        if (updated is null) throw new KeyNotFoundException($"Car by Id: {id} is not found");

        _unitOfWork.Commit();
        return updated.ToUpdateCarDTO();
    }
    public Car Delete(int id)
    {
        var carId = _unitOfWork.Cars.GetById(c => c.Id == id);
        if (carId is null) throw new KeyNotFoundException($"Car by Id: {id} is not found");
        var deleted = _unitOfWork.Cars.Delete(carId);
        _unitOfWork.Commit();

        return deleted;
    } 
}
