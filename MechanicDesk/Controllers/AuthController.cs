using MechanicDesk.DataBase;
using MechanicDesk.DTOs.LoginDTO;
using MechanicDesk.DTOs.RegisterDTO;
using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MechanicDesk.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IRegisterService _registerService;
    private readonly ILoginService _loginService;
    private readonly AppDbContext _context;
    public AuthController(IRegisterService registerService, ILoginService loginService, AppDbContext context)
    {
        _registerService = registerService;
        _loginService = loginService;
        _context = context;
    }

    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult Register(RegisterDTO registerDTO)
    {
        try
        {
            var user = _registerService.Register(registerDTO);
            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
        }
        catch(InvalidOperationException)
        {
            return BadRequest("Username already exists");
        }
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Login(LoginDTO loginDTO)
    {
        try
        {
            var token = _loginService.Login(loginDTO);
            return Ok(new { token });
        } catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("Incorrect username or password");
        }
    }

    [HttpGet]
    [Authorize(Roles = "manager, admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<IEnumerable<User>> GetAllUser()
    {
        return _registerService.GetAllUsers().ToList();
    }


    [HttpDelete("{id:int}")]
    [Authorize(Roles = "manager")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
       
            var user = _context.Set<User>().FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound("User not found");
            _context.Set<User>().Remove(user);
            _context.SaveChanges();

            return Ok(user);             
    }
}
