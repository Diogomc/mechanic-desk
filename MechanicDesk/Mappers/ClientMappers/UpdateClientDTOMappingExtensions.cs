using MechanicDesk.DTOs.ClientDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Mappers.ClientMappers;

public static class UpdateClientDTOMappingExtensions
{
    public static void ToUpdateClient(this UpdateClientDTO updateClientDTO, Client client)
    {
            client.Name = updateClientDTO.Name;
            client.PhoneNumber = updateClientDTO.PhoneNumber;
            client.BirthDate = updateClientDTO.BirthDate;
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
