using MechanicDesk.DataBase;
using MechanicDesk.DTOs.LoginDTO;
using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MechanicDesk.Services;

public class LoginService : ILoginService
{
    private readonly AppDbContext _appDbContext;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<User> _passwordHasher;
    public LoginService(AppDbContext appDbContext, IConfiguration configuration)
    {
        _appDbContext = appDbContext;
        _configuration = configuration;
        _passwordHasher = new PasswordHasher<User>();
    }
    public string Login(LoginDTO loginDTO)
    {
        var user = _appDbContext.Set<User>().FirstOrDefault(u => u.UserName == loginDTO.UserName);

        if (user == null) throw new KeyNotFoundException("Incorrect username or password");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDTO.Password);

        if (result == PasswordVerificationResult.Failed) throw new UnauthorizedAccessException();

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
