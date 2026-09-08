using MechanicDesk.DTOs;
using MechanicDesk.DTOs.LoginDTO;
using MechanicDesk.Models;
using MechanicDesk.Services;
using MechanicDesk.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MechanicDesk.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IRegisterServices _services;
    private readonly IConfiguration _configuration;

    public AuthController(IRegisterServices registerServices, IConfiguration configuration)
    {
        _services = registerServices;
        _configuration = configuration;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterDTO registerDTO)
    {
        var user = _services.Register(registerDTO);
        return Ok(new { message = "Operation sucefull", user });
    }

    // Endpoint de login
    [HttpPost("login")]
    public IActionResult Login(LoginDTO loginDTO)
    {
        // Aqui você buscaria o usuário no banco (exemplo simplificado)
        var user = _services.FindByUserName(loginDTO.UserName);
        if (user == null) return Unauthorized("Usuário não encontrado");

        // Verifica a senha com PasswordHasher
        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, loginDTO.Password);

        if (result == PasswordVerificationResult.Failed)
            return Unauthorized("Senha incorreta");

        // Se a senha está correta, gera o JWT
        var token = GenerateJwtToken(user);

        return Ok(new { token });
    }
    [HttpGet]
    public ActionResult<User> GetUsers(string name)
    {
        return _services.FindByUserName(name);
    }

    // Método privado para gerar o JWT
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
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

