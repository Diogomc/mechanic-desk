using MechanicDesk.DTOs.CarDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Mappers.CarMappers;

public static class UpdateCarDTOMappingExtensions
{
    public static Car ToUpdateCar(this UpdateCarDTO updateCarDTO)
    {
        return new Car
        {
            Id = updateCarDTO.Id,
            Model = updateCarDTO.Model,
            Year = updateCarDTO.Year,
            Brand = updateCarDTO.Brand,
            LicencePlate = updateCarDTO.LicencePlate,
            ClientId = updateCarDTO.ClientId
        };
    }
    public static UpdateCarDTO ToUpdateCarDTO(this Car car)
    {
        return new UpdateCarDTO
        {
            Id = car.Id,
            Model = car.Model,
            Year = car.Year,
            Brand = car.Brand,
            LicencePlate = car.LicencePlate,
            ClientId = car.ClientId
        };
    }
}
