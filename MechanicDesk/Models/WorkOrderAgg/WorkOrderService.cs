namespace MechanicDesk.Models.WorkOrderAgg;

public class WorkOrderService
{
    public int Id { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; }

}
