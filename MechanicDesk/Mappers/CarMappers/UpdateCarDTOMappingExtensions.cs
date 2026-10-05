using MechanicDesk.DTOs.CarDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Mappers.CarMappers;

public static class UpdateCarDTOMappingExtensions
{
    public static void ToUpdateCar(this UpdateCarDTO updateCarDTO, Car car)
    {
        
        {
            car.Id = updateCarDTO.Id;
            car.Model = updateCarDTO.Model;
            car.Year = updateCarDTO.Year;
            car.Brand = updateCarDTO.Brand;
            car.LicencePlate = updateCarDTO.LicencePlate;
            car.ClientId = updateCarDTO.ClientId;
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
