using MechanicDesk.DTOs.WorkOrderDTO;
using MechanicDesk.Mappers.WorkOrderMappers;
using MechanicDesk.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MechanicDesk.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkOrderController : ControllerBase
{
    private readonly IWorkOrderService _workOrderService;
    public WorkOrderController(IWorkOrderService workOrderService)
    {
        _workOrderService = workOrderService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<GetWorkOrderDTO>> GetAllWorkOrders()
    {
        return Ok(_workOrderService.GetAllWorkOrders());
    }

    [HttpGet("{id:int}", Name = "GetWorkOrderById")]
    public ActionResult<GetWorkOrderDTO> GetById(int id)
    {
        var workOrder = _workOrderService.GetById(id);

        return Ok(workOrder);
    }

    [HttpPost]
    public ActionResult<GetWorkOrderDTO> CreateWorkOrder(CreateWorkOrderDTO createWorkOrderDTO)
    {
        try {
            var create = _workOrderService.CreateWorkOrder(createWorkOrderDTO);
            return CreatedAtAction(nameof(GetById), new { id = create.Id}, create);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPut("{id:int}")]
    public ActionResult<UpdateWorkOrderDTO> UpdateWorkOrder(int id, UpdateWorkOrderDTO updateWorkOrderDTO)
    {
        try
        {
            var update = _workOrderService.UpdateWorkOrder(id, updateWorkOrderDTO);
            return Ok(update);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public ActionResult DeleteWorkOrder(int id)
    {
        try
        {
            var deleted = _workOrderService.Delete(id);
            return Ok(deleted);
        }
        catch(KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
