namespace MechanicDesk.Models.WorkOrderAgg;

public class WorkOrderParts
{
    public int Id { get; set; }
    public string PartName { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; }
}
