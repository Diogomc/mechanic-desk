using MechanicDesk.Models.WorkOrderAgg;

namespace MechanicDesk.Models;

public class Car
{
    public int CarId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string LicencePlate { get; set; } = string.Empty;

    public int ClientId { get; set; }
    public Client Client { get; set; } 

    public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();

}
