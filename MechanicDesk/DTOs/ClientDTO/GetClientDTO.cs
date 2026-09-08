namespace MechanicDesk.DTOs.ClientDTO;

public class GetClientDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}
