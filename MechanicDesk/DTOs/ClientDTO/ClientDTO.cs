using MechanicDesk.DTOs.CarDTO;

namespace MechanicDesk.DTOs.ClientDTO;

public class ClientDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public List<GetCarDTO> Cars { get; set; } = new();
}
