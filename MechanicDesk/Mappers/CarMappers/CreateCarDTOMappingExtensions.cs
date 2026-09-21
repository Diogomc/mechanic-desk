using MechanicDesk.DTOs.CarDTO;
using MechanicDesk.Models;
using System.Runtime.ConstrainedExecution;

namespace MechanicDesk.Mappers.CarMappers;

public static class CreateCarDTOMappingExtensions
{
    public static Car ToCreateCar(this CreateCarDTO createCarDTO)
    {
        return new Car
        {
            Model = createCarDTO.Model,
            Year = createCarDTO.Year,
            Brand = createCarDTO.Brand,
            LicencePlate = createCarDTO.LicencePlate,
            ClientId = createCarDTO.ClientId
        };
    }
    public static CreateCarDTO ToCreateCarDTO(this Car car)
    {
        return new CreateCarDTO
        {
            Model = car.Model,
            Year = car.Year,
            Brand = car.Brand,
            LicencePlate = car.LicencePlate,
        };
    }
}
