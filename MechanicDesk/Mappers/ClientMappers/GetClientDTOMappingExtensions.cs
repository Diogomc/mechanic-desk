using MechanicDesk.DTOs.CarDTO;
using MechanicDesk.DTOs.ClientDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Mappers.ClientMappers;

public static class GetClientDTOMappingExtensions
{
    public static Client ToClient (this GetClientDTO getClientDTO)
    {
        return new Client
        {
            Id = getClientDTO.Id,
            BirthDate = getClientDTO.BirthDate,
            Name = getClientDTO.Name,
            PhoneNumber = getClientDTO.PhoneNumber,
        };
    }
    public static GetClientDTO ToGetClientDTO (this Client client)
    {
        return new GetClientDTO
        {
            Id = client.Id,
            BirthDate = client.BirthDate,
            Name = client.Name,
            PhoneNumber = client.PhoneNumber,
            Cars = client.Cars.Select(car => new GetCarDTO
            {
                Id = car.Id,
                Model = car.Model,
                Year = car.Year,
                Brand = car.Brand,
                LicencePlate = car.LicencePlate,
                ClientId = car.ClientId
            }).ToList()
        };
    }
    public static IEnumerable<GetClientDTO> ToGetClientDTOList(this IEnumerable<Client> clients)
    {
        return clients.Select(clients => new GetClientDTO
        {
            Id = clients.Id,
            BirthDate = clients.BirthDate,
            Name = clients.Name,
            PhoneNumber = clients.PhoneNumber,
            Cars = clients.Cars.Select(car => new GetCarDTO
            {
                Model = car.Model,
                Year = car.Year,
                Brand = car.Brand,
                LicencePlate = car.LicencePlate,
                ClientId = car.ClientId
            }).ToList()
        }).ToList();
    }
}
