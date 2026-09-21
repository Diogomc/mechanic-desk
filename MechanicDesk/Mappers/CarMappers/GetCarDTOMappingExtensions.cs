using MechanicDesk.DTOs.CarDTO;
using MechanicDesk.Models;
using System.Runtime.ConstrainedExecution;

namespace MechanicDesk.Mappers.CarMappers;

public static class GetCarDTOMappingExtensions
{
    public static Car ToCar(this GetCarDTO getCarDTO)
    {
        return new Car
        {
            Id = getCarDTO.Id,
            Model = getCarDTO.Model,
            Year = getCarDTO.Year,
            Brand = getCarDTO.Brand,
            LicencePlate = getCarDTO.LicencePlate,
        };
    }
    public static GetCarDTO ToCarDTO (this Car car)
    {
        return new GetCarDTO
        {
            Id = car.Id,
            Model = car.Model,
            Year = car.Year,
            Brand = car.Brand,
            LicencePlate = car.LicencePlate,
            ClientId = car.ClientId
        };
    }
    public static IEnumerable<GetCarDTO> ToCarDTOList(this IEnumerable<Car> cars)
    {
        return cars.Select(cars => new GetCarDTO
        {
            Id = cars.Id,
            Model = cars.Model,
            Year = cars.Year,
            Brand = cars.Brand,
            LicencePlate = cars.LicencePlate,
            ClientId = cars.ClientId
        });
        
    }

}
