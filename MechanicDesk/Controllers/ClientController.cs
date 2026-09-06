using MechanicDesk.DTOs.ClientDTO;
using MechanicDesk.Mappers.ClientMappers;
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
            var client = _clientServices.GetById(id);
            return Ok(client);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Client by id: {id} is not found");
        }
    }
    [HttpPost]
    public ActionResult<ClientDTO> CreateClient(CreateClientDTO createClientDTO)
    {
        try {
            var create = _clientServices.Create(createClientDTO);

            return CreatedAtAction(nameof(GetById), new { id = create.Id }, create);

        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateClient(int id, Client client)
    {
       var update = _clientServices.Update(id, client);
        return Ok(update);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteClient(int id)
    {
        var delete = _clientServices.Delete(id);

        return Ok(delete);
    }      
                
}
