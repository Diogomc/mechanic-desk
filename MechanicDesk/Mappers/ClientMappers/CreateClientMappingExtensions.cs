using MechanicDesk.DTOs.ClientDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Mappers.ClientMappers;

public static class CreateClientMappingExtensions
{
    public static Client ToClient(this CreateClientDTO createClientDTO)
    {
        return new Client
        {
            Name = createClientDTO.Name,
            PhoneNumber = createClientDTO.PhoneNumber,
            BirthDate = createClientDTO.BirthDate
        };
    }
    
    public static CreateClientDTO ToCreateClientDTO(Client client)
    {
        return new CreateClientDTO
        {
            Name = client.Name,
            PhoneNumber = client.PhoneNumber,
            BirthDate = client.BirthDate
        };

    }
}
