using MechanicDesk.DTOs.RegisterDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Mappers.RegisterMappers;

public static class RegisterMappingExtensions
{
    public static User ToUserRegister(this RegisterDTO registerDTO)
    {
        return new User
        {
            UserName = registerDTO.UserName,
            Role = registerDTO.Role,
        };
    }
    public static RegisterDTO ToUserRegisterDTO(this User user)
    {
        return new RegisterDTO
        {
            UserName = user.UserName,
            Role = user.Role,
        };
    }
}
