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
    public IActionResult Register(RegisterDTO registerDTO)
    {
        try
        {
            var user = _registerService.Register(registerDTO);
            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Login")]
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
    [Authorize(Roles = "Manager")]
    public ActionResult<IEnumerable<User>> GetAllUser()
    {
        return _registerService.GetAllUsers().ToList();
    }

    [HttpDelete]
    [Authorize(Roles = "Manager")]
    public IActionResult Delete(string name)
    {
        try
        {
            var delete = _registerService.FindUserByName(name);
            if (name == null) return NotFound("User is not found");
            _context.Set<User>().Remove(delete);
            _context.SaveChanges();

            return Ok(delete);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("You can't delete user");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        

    }
}
