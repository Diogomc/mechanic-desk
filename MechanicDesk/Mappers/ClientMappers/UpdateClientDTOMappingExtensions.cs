using MechanicDesk.DTOs.ClientDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Mappers.ClientMappers;

public static class UpdateClientDTOMappingExtensions
{
    public static Client ToClient(this UpdateClientDTO updateClientDTO)
    {
        return new Client
        {
            Id = updateClientDTO.Id,
            Name = updateClientDTO.Name,
            PhoneNumber = updateClientDTO.PhoneNumber,
            BirthDate = updateClientDTO.BirthDate,
        };
    }
    public static UpdateClientDTO ToUpdateClientDTO(this Client client)
    {
        return new UpdateClientDTO
        {
            Id = client.Id,
            Name = client.Name,
            BirthDate = client.BirthDate,
            PhoneNumber = client.PhoneNumber,
        };
    }
}
