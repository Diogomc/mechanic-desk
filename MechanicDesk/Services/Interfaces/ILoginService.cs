using MechanicDesk.DTOs.LoginDTO;

namespace MechanicDesk.Services.Interfaces;

public interface ILoginService
{
    public string Login(LoginDTO loginDTO);
}
