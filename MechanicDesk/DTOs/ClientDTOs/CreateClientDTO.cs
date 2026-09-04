namespace MechanicDesk.DTOs.ClientDTOs;

public class CreateClientDTO
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}
