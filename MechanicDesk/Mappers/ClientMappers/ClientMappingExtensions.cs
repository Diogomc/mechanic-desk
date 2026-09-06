using MechanicDesk.DTOs.ClientDTO;
using MechanicDesk.Models;
using System.Runtime.CompilerServices;

namespace MechanicDesk.Mappers.ClientMappers;

public static class ClientMappingExtensions
{
    public static ClientDTO ToClientDTO(this Client client)
    {
        return new ClientDTO
        {
            Name = client.Name,
            PhoneNumber = client.PhoneNumber,
            BirthDate = client.BirthDate,
        };
    }

    public static Client ToClient(this ClientDTO clientDTO)
    {
        return new Client
        {
            Name = clientDTO.Name,
            PhoneNumber = clientDTO.PhoneNumber,
            BirthDate = clientDTO.BirthDate,
        };
    }
}
