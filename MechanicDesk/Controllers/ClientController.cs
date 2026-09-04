using MechanicDesk.Models;
using MechanicDesk.Repository.ClientRepository;
using MechanicDesk.Services;
using MechanicDesk.Services.Interfaces;
using MechanicDesk.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MechanicDesk.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientServices _clientServices;

    public ClientController(IClientServices clientServices)
    {
        _clientServices = clientServices;
    }

    [HttpGet]
    public IEnumerable<Client> GetAllClients()
    {    
        return _clientServices.GetAll();            
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        try { 
            var client = _clientServices.GetById(c => c.Id == id);
            return Ok(client);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Client by id: {id} is not found");
        }

    }


}
