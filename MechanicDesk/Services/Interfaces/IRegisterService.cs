using MechanicDesk.DTOs.RegisterDTO;
using MechanicDesk.Models;

namespace MechanicDesk.Services.Interfaces;

public interface IRegisterService
{
    User FindUserByName (string name);
    User Register(RegisterDTO registerDTO);
    IEnumerable<User> GetAllUsers();
}
