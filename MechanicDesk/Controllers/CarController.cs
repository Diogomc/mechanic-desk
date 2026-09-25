using MechanicDesk.DTOs.CarDTO;
using MechanicDesk.Models;
using MechanicDesk.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MechanicDesk.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarServices _carServices;

    public CarController(ICarServices carServices)
    {
        _carServices = carServices;
    }

    [HttpGet]
    public ActionResult<IEnumerable<GetCarDTO>> GetAllCars()
    {
        return Ok(_carServices.GetAllCars());
    }

    [HttpGet("{id:int}", Name = "GetCarById")]
    public ActionResult<GetCarDTO> GetCarById(int id)
    {
        try
        {
            return Ok(_carServices.GetCarByID(id));
        }
        catch (KeyNotFoundException ex)
        {
            return Ok(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<GetCarDTO> CreateCar(CreateCarDTO createCarDTO)
    {
        try
        {
            var create = _carServices.CreateCar(createCarDTO);
            return CreatedAtAction(nameof(GetCarById), new { id = create.Id }, create);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<UpdateCarDTO> UpdateCar(int id, UpdateCarDTO updateCarDTO)
    {
        try
        {
            var update = _carServices.UpdateCar(id, updateCarDTO);
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
    public ActionResult<Car> DeleteCar(int id)
    {
        var car = _carServices.Delete(id);

        return Ok(car);
    }
   
}
