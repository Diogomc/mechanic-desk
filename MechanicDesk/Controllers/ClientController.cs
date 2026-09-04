using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;
using MechanicDesk.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MechanicDesk.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IEnumerable<Client> GetAllClients()
    {
        return _unitOfWork.Clients.GetAll();
    }
}
