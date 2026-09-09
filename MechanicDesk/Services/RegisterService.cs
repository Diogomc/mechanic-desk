using MechanicDesk.DataBase;
using MechanicDesk.DTOs.RegisterDTO;
using MechanicDesk.Mappers.RegisterMappers;
using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MechanicDesk.Services;

public class RegisterService : IRegisterService
{
    private readonly AppDbContext _appDbContext;
    private readonly PasswordHasher<User> _passwordHasher;
    public RegisterService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _passwordHasher = new PasswordHasher<User>();
    }

    public User FindUserByName(string name)
    {
        var userName = _appDbContext.Set<User>().FirstOrDefault(c => c.UserName == name);

        if (userName == null) throw new KeyNotFoundException("User not found");

        return userName;
    }
    public IEnumerable<User> GetAllUsers()
    {
        return _appDbContext.Users.ToList();
    }

    public User Register(RegisterDTO registerDTO)
    {
        var user = registerDTO.ToUserRegister();

        user.PasswordHash = _passwordHasher.HashPassword(user, registerDTO.Password);

        _appDbContext.Set<User>().Add(user);
        _appDbContext.SaveChanges();

        return user;
    }
}
