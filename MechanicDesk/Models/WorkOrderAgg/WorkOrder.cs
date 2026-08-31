namespace MechanicDesk.Models.WorkOrderAgg;

public class WorkOrder
{
    public int Id { get; set; }
    public string ProblemDescription { get; set; } = string.Empty;
    public DateTime InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }
    public string WorkerName { get; set; } = string.Empty;


    public List<WorkOrderService> WorkOrderServices { get; set; } = new ();
    public List<WorkOrderParts> WorkOrderParts { get; set; } = new ();


    public int ClientId { get; set; }
    public Client Client { get; set; }

    
    public int CarId { get; set; }
    public Car Car { get; set; }
}
