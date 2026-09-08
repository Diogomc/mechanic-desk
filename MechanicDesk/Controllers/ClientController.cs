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
    public ActionResult<IEnumerable<GetClientDTO>> GetAllClients()
    {
        return Ok(_clientServices.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<GetClientDTO> GetById(int id)
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
    public ActionResult<UpdateClientDTO> UpdateClient(int id, UpdateClientDTO updateClientDTO)
    {
        try
        {
            var update = _clientServices.Update(id, updateClientDTO);
            return Ok(update);
        }
        catch (ArgumentException ae)
        {
            return BadRequest(ae.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }      
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteClient(int id)
    {
        try { 
            var delete = _clientServices.Delete(id);
            return Ok(delete);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }      
                
}
