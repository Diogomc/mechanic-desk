using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public ICollection<Car> Cars { get; set; } = new List<Car>();

    public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
