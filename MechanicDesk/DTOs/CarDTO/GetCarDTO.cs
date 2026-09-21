namespace MechanicDesk.DTOs.CarDTO;

public class GetCarDTO 
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string LicencePlate { get; set; } = string.Empty;
    public int ClientId { get; set; }
}
