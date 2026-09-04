using MechanicDesk.DTOs.ClientDTOs;
using MechanicDesk.Models;

namespace MechanicDesk.Mappers.ClientMappers;

public static class CreateClientDTOMappingExtensions
{
    public static CreateClientDTO ToCreateClientDTO(this Client Client)
    {
        return new CreateClientDTO
        {
            Name = Client.Name,
            PhoneNumber = Client.PhoneNumber,
            BirthDate = Client.BirthDate,
        };
    }

}
