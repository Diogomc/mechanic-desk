namespace MechanicDesk.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public Car Car { get; set; }
}
